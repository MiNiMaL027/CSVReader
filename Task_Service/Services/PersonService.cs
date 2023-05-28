using Task_Domain.Models;
using Task_Service.Interfaces;
using Task_Repositories.Interfaces;
namespace Task_Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _uploadRepository;

        public PersonService(IPersonRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }
        
        public async Task<IQueryable<Person>> GetAll()
        {
            return await _uploadRepository.GetAll();
        }

        public async Task Update(Person data)
        {
            await _uploadRepository.Update(data);
        }

        public async Task HardDelete(int id)
        {
            await _uploadRepository.HardDelete(id);
        }

        public async Task Delete(int id)
        {
            await _uploadRepository.Delete(id);
        }
    }
}
