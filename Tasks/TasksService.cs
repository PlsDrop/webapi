using System;
using System.Collections.Generic;

namespace webapi
{
    public class  TasksService
    {
        private List<Task> tasksList = new List<Task>
            {
                new Task() {id = 1, title = "Go outside"},
                new Task() {id = 2, title = "Buy food"}
            };
        private int lastId = 2; 
        
        public List<Task> GetAll()
        {
            return tasksList;
        }
        public Task Create(Task item)
        {
            item.id = ++lastId;
            tasksList.Add(item);
            return item;
            // return Created($"tasks/{item.id}", item);
        }

        public Task Get(int id)
        {
            return tasksList[id - 1];
        }
    }
}