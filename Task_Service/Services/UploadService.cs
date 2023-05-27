using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Task_Domain.DTOModels;
using Task_Domain.Exeptions;
using Task_Domain.Models;
using Task_Repositories.Interfaces;
using Task_Service.Interfaces;

namespace Task_Service.Services
{
    public class UploadService : IUploadService
    {
        private readonly IMapper _mapper;

        private readonly IPersonRepository _uploadRepository;

        public UploadService(IPersonRepository uploadRepository, IMapper mapper)
        {
            _uploadRepository = uploadRepository;
            _mapper = mapper;
        }

        public async Task UploadPersons(IFormFile csvFile)
        {
            if (csvFile != null && csvFile.Length > 0)
            {
                using (var reader = new StreamReader(csvFile.OpenReadStream()))
                {
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = new List<Person>();

                        while (csvReader.Read())
                        {
                            var record = csvReader.GetRecord<DtoPerson>();

                            if (record == null)
                                throw new NullReferenceException();

                            records.Add(_mapper.Map<Person>(record));
                        }

                        await _uploadRepository.AddRange(records);
                    }
                }
            }
            else
                throw new FileValidationException();
        }
    }
}
