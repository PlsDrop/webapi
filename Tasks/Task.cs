using System;

namespace webapi
{
    public class Task
    {
        public int id { get; set; }
        public DateTime? dueDate { get; set; }
    
        public string title { get; set; }

        public string description { get; set; }
        public bool done { get; set; }
    }
}
