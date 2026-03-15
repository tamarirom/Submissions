using lesson_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class FakeContext : IDataContext
    {
        public List<Employee> Employees { get; set; }

        public FakeContext()
        {
            Employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Shimi", Position = "Developer" },
                new Employee { Id = 2, Name = "Yair", Position = "Manager" },
                new Employee { Id = 3, Name = "Yael", Position = "Secretary" },
            };
        }
    }
}
