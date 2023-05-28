using Microsoft.EntityFrameworkCore;
using Task_Domain.Exeptions;
using Task_Domain.Models;
using Task_Repositories.Interfaces;

namespace Task_Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _db;

        public PersonRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddRange(List<Person> file)
        {
            await _db.AddRangeAsync(file);
            await _db.SaveChangesAsync();
        }

        public async Task<IQueryable<Person>> GetAll()
        {
            return _db.Persons.Where(x => x.IsArсhived == false);
        }

        public async Task<bool> Update(Person data)
        {
            _db.Update(data);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HardDelete(int id)
        {
            var toDelete = await _db.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (toDelete == null)
                throw new NotFoundException();

            _db.Remove(toDelete);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var toDelete = await _db.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (toDelete == null)
                throw new NotFoundException();

            toDelete.IsArсhived = true;

            return true;
        }
    }
}
