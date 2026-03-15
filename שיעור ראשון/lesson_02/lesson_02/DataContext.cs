using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;

namespace lesson_02
{
    public class DataContext : IDataContext
    {
        public List<Employee> Employees { get; set; }

        public DataContext()
        {
            using (var reader = new StreamReader("Data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Employees = csv.GetRecords<Employee>().ToList();
            }
        }
    }
}
