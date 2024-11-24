namespace Zay_Projects.Utilities.File
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file,string folder)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(_webHostEnvironment.WebRootPath,folder,fileName);
            using (var fileStream= new FileStream(path,FileMode.Create,FileAccess.ReadWrite))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
        public void Delete(string folder,string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath,folder,fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);

            }
           
        }
        public bool IsImage(string contentType)
        {
            if (contentType.Contains("image/")) return true;
          return false;
        }

        public bool IsAvialableSize(long length,long maxLength)
        {
            if (length/1024<=maxLength) return true;
            return false;
        }
    }
}
