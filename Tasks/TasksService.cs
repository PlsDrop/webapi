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

        public Task Replace(int id, Task item)
        {
            tasksList.RemoveAt(id - 1);
            item.id = id;
            tasksList.Add(item);
            return item;
        }
        public Task Patch(int id, Task item)
        {
            id =- 1;
            if(item.description != tasksList[id].description)
                tasksList[id].description = item.description;

            if(item.title != tasksList[id].title)
                tasksList[id].title = item.title;

            if(item.dueDate != tasksList[id].dueDate)
                tasksList[id].dueDate = item.dueDate;

            if(item.done != tasksList[id].done)
                tasksList[id].done = item.done;

            return tasksList[id];
        }

        public void Delete(int id)
        {
            tasksList.RemoveAt(id - 1); 
        }
    }
}