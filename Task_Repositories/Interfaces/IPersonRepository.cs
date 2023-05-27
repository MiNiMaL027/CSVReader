using Task_Domain.Models;

namespace Task_Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task AddRange(List<Person> file);
        Task<IQueryable<Person>> GetPerson();
        Task<bool> UpdateData(Person data);
        Task<bool> DeleteData(List<int> ids);
    }
}
