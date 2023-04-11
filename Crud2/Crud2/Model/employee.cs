using System.ComponentModel.DataAnnotations;

namespace Crud2.Model
{
    public class employee
    {
        [Key]
        public  int id { get; set; } 
        public string name { get; set; }

       
        public string sex { get; set; }
        public string maritalstatus { get; set; }

        public string address { get; set; }

        public string department { get; set; }

        public ICollection<empsalary> empsalaries { get; set; }
    }
}
