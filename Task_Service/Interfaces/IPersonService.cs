using Task_Domain.Models;

namespace Task_Service.Interfaces
{
    public interface IPersonService
    {
        Task<IQueryable<Person>> GetAll();

        Task Update(Person data);

        Task HardDelete(int id);

        Task Delete(int id);
    }
}
