using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees { get; set; } = new List<Employee>
        {
            new Employee { Id = 1, Name = "Shimi", Position = "Software Engineer" },
            new Employee { Id = 2, Name = "Yair", Position = "Project Manager" },
            new Employee { Id = 3, Name = "Yael", Position = "QA Analyst" }
        };

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee e)
        {
            int newId;

            if (employees.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = employees.Max(x => x.Id) + 1;
            }

            e.Id = newId;

            employees.Add(e);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee e)
        {
            var employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                employee.Name = e.Name;
                employee.Position = e.Position;
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
                employees.Remove(employee);
        }
    }
}
