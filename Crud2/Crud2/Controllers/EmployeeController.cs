using Crud2.Database;
using Crud2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDBcontext EmpDBContext;
        public EmployeeController(EmployeeDBcontext employeeDBcontext)
        {
            this.EmpDBContext = employeeDBcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var Employees = await EmpDBContext.Employees.Include(x=>x.empsalaries).ToListAsync();
            List<EmployeeCombine> Empcomb = new List<EmployeeCombine>();
            foreach (var item in Employees)
            {
                EmployeeCombine Empcombine = new EmployeeCombine();
                
                Empcombine.id = item.id;
                Empcombine.name = item.name;
                Empcombine.department = item.department;
                Empcombine.address = item.address;
                Empcombine.maritalstatus = item.maritalstatus;
                Empcombine.sex = item.sex;
                foreach (var item2 in item.empsalaries)
                {
                    Empcombine.salary = item2.salary;
                    Empcombine.empid = item2.empid;
                }
                Empcomb.Add(Empcombine);
            }
            return Ok(Empcomb);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCombine emp)
        {
            
            employee Empc = new employee();
            Empc.id = 0;
            Empc.address = emp.address;
            Empc.department=emp.department;
            Empc.name=emp.name;
            Empc.maritalstatus=emp.maritalstatus;
            Empc.sex=emp.sex;
            empsalary emps=new empsalary();
            await EmpDBContext.Employees.AddAsync(Empc);
            emps.empid=emp.empid;
            emps.salary = emp.salary;
            emps.employ = Empc;
            await EmpDBContext.EmployeesSalary.AddAsync(emps);
            await EmpDBContext.SaveChangesAsync();
            return Ok(emp);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id,[FromBody] EmployeeCombine emp)
        {
            var employee = await EmpDBContext.Employees.Include(x=>x.empsalaries).FirstOrDefaultAsync(a => a.id == id);
            var employeesalary = await EmpDBContext.EmployeesSalary.FirstOrDefaultAsync(a => a.empid == emp.empid);
            if (employee != null && employeesalary != null)
            {
                employee.address = emp.address;
                employee.department = emp.department;
                employee.name = emp.name;
                employee.maritalstatus = emp.maritalstatus;
                employee.sex = emp.sex; 
                EmpDBContext.Employees.Update(employee);

                employeesalary.empid = emp.empid;
                employeesalary.salary = emp.salary;
                employeesalary.employ = employee;
                EmpDBContext.EmployeesSalary.Update(employeesalary);
                EmpDBContext.SaveChanges();
                return Ok(emp);
            }
            else
            {
                return NotFound("EmployeenotFound");
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await EmpDBContext.Employees.FirstOrDefaultAsync(a => a.id == id);
            if (employee != null)
            {
                EmpDBContext.Employees.Remove(employee);
                await EmpDBContext.SaveChangesAsync();

                return Ok(employee);
            }
            else
            {

                return NotFound("EmployeeNotFound");
            }

        }

    }
}
