using System;
using System.Collections.Generic;

namespace webapi
{
    public class TaskList<Task> : List<Task>
    { 
        public string title { get; set; }
        public int id { get; set; }
        public int lastTaskId = 2;
    }
}