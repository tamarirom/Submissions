using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Status myStatus { get; set; }
        public enum Status
        {
            ToDo,
            InAction,
            Completed
        }
    }
}
