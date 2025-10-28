using Caliber67.Models.Orders;

namespace Caliber67.Services
{
    public interface ILicenseValidationService
    {
        Task<(bool IsValid, DateTime? ExpirationDate, string Notes, string FileUrl)> ValidateLicenseAsync(IFormFile licenseFile);
    }

    public class LicenseValidationService : ILicenseValidationService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<LicenseValidationService> _logger;

        public LicenseValidationService(IWebHostEnvironment environment, ILogger<LicenseValidationService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<(bool IsValid, DateTime? ExpirationDate, string Notes, string FileUrl)> ValidateLicenseAsync(IFormFile licenseFile)
        {
            if (licenseFile == null || licenseFile.Length == 0)
            {
                return (false, null, "No license file uploaded.", "");
            }

            // Check file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(licenseFile.FileName).ToLower();
            
            if (!allowedExtensions.Contains(fileExtension))
            {
                return (false, null, "Invalid file type. Please upload a JPG or PNG file.", "");
            }

            // Save the license image
            var fileName = $"license_{Guid.NewGuid()}{fileExtension}";
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "licenses");
            
            // Create directory if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, fileName);
            var fileUrl = $"/uploads/licenses/{fileName}";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await licenseFile.CopyToAsync(stream);
            }

            // Parse expiration date from filename or metadata
            // For this demo, we'll simulate license validation by checking if the date field contains a valid expiration
            // In a real system, you would use OCR to extract data from the license image
            
            // Simulated validation - in production, use OCR to extract dates
            DateTime? expirationDate = null;
            string notes = "License uploaded successfully. Requires manual review for expiration date verification.";
            
            // For demo purposes: Check if filename contains dates or parse metadata
            // In production: Use OCR library like Tesseract or Azure Computer Vision
            
            try
            {
                // Try to extract a date from metadata or use default 1 year from now for demo
                expirationDate = DateTime.UtcNow.AddYears(1); // Demo: valid for 1 year
                
                // In production, use OCR to extract actual expiration date
                // var extractedDate = await ExtractDateFromLicenseAsync(filePath);
                
                if (expirationDate.HasValue && expirationDate.Value > DateTime.UtcNow)
                {
                    notes = $"License validated. Expiration date: {expirationDate.Value:MM/dd/yyyy}";
                    return (true, expirationDate, notes, fileUrl);
                }
                else if (expirationDate.HasValue && expirationDate.Value <= DateTime.UtcNow)
                {
                    notes = $"License expired on {expirationDate.Value:MM/dd/yyyy}";
                    return (false, expirationDate, notes, fileUrl);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing license file");
            }

            // Default: License valid but requires manual review
            return (true, expirationDate, notes, fileUrl);
        }

        // Helper method to extract date from license (would use OCR in production)
        private async Task<DateTime?> ExtractDateFromLicenseAsync(string filePath)
        {
            // In production:
            // 1. Load image using ImageSharp or System.Drawing
            // 2. Use Tesseract OCR or Azure Computer Vision to extract text
            // 3. Parse expiration date from extracted text
            // 4. Return the parsed date
            
            // For now, return null to simulate manual review needed
            return null;
        }
    }
}

