using System.ComponentModel.DataAnnotations;

namespace SampleRestfulAPI
{
    public class Employee
    {

        [Required] public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public int? Address_ID { get; set; }
        public int? Department_ID { get; set; }
    }
}
