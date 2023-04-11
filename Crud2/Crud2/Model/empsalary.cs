using System.ComponentModel.DataAnnotations;
namespace Crud2.Model
{
    public class empsalary
    {
        [Key]   
        public int empid { get; set; }
        public int salary { get; set; }

        public employee employ { get; set; }
    }
}
