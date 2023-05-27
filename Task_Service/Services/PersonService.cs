using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;
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
            return await _uploadRepository.GetPerson();
        }

        public async Task UpdateData(Person data)
        {
            await _uploadRepository.UpdateData(data);
        }

        public async Task DeleteData(List<int> ids)
        {
            await _uploadRepository.DeleteData(ids);
        }
    }
}
