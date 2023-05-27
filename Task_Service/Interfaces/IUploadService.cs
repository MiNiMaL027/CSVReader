using Microsoft.AspNetCore.Http;

namespace Task_Service.Interfaces
{
    public interface IUploadService
    {
        Task UploadPersons(IFormFile csvFile);
    }
}
