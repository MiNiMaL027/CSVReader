using Task_Domain.Models;

namespace Task_Service.Interfaces
{
    public interface IPersonService
    {
        Task<IQueryable<Person>> GetAll();

        Task UpdateData(Person data);

        Task DeleteData(int id);
    }
}
