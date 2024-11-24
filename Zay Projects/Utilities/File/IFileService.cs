namespace Zay_Projects.Utilities.File
{
    public interface IFileService
    {
        string Upload (IFormFile file,string folder);
        void Delete(string folder, string fileName);
        bool IsImage(string contentType);
        bool IsAvialableSize(long length, long maxLength);
    }
}
