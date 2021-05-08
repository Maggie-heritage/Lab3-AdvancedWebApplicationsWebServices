using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWebAPI.Model
{
    public class ToDoItem
    {
        public long ID { get; set; }
        public string Task { get; set; }
        public string Location { get; set; }
        public DateTime Deadline { get; set; }
        public string Responsible { get; set; }
        public bool IsComplete { get; set; }
    }
}

