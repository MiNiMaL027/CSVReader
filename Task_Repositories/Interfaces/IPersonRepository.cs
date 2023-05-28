using Task_Domain.Models;

namespace Task_Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task AddRange(List<Person> file);
        Task<IQueryable<Person>> GetAll();
        Task<bool> Update(Person data);
        Task<bool> HardDelete(int id);
        Task<bool> Delete(int id);
    }
}
