namespace Task_Domain.Exeptions
{
     public class FileValidationException : Exception
     {
        public FileValidationException(string message) : base(message) { }

        public FileValidationException() { }
     }
}
