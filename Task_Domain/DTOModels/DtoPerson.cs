using CsvHelper.Configuration.Attributes;

namespace Task_Domain.DTOModels
{
    public class DtoPerson
    {
        [Name("Name")]
        public string Name { get; set; }

        [Name("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Name("Married")]
        public bool Married { get; set; }

        [Name("Phone")]
        public string Phone { get; set; }

        [Name("Salary")]
        public decimal Salary { get; set; }
    }
    
}
