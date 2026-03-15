using Microsoft.AspNetCore.Mvc;

namespace lesson_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly IDataContext _context;

        public EmployeesController(IDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employees;
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _context.Employees.Find(e => e.Id == id);
        }

        // POST api/employees
        [HttpPost]
        public void Post([FromBody] Employee e)
        {
            int newId;

            if (_context.Employees.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = _context.Employees.Max(x => x.Id) + 1;
            }

            e.Id = newId;

            _context.Employees.Add(e);
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee e)
        {
            var employee = _context.Employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                employee.Name = e.Name;
                employee.Position = e.Position;
            }
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = _context.Employees.Find(e => e.Id == id);
            if (employee != null)
                _context.Employees.Remove(employee);
        }
    }
}
