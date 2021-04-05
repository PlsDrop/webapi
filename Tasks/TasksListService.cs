using System;
using System.Collections.Generic;

namespace webapi
{
    public class  TasksListService
    {
        private List<TaskList<Task>> listOfTasksLists = new List<TaskList<Task>>();

        private TaskList<Task> tasksList = new TaskList<Task>
            {
                new Task() {id = 1, title = "Go outside"},
                new Task() {id = 2, title = "Buy food"}
            };
        private int lastListId = 0; 

        public TasksListService()
        {
            CreateList("Example task list.");  
        }

        
        public TaskList<Task> CreateList(string name)
        {
            tasksList.title = name;
            tasksList.id = ++lastListId;
            listOfTasksLists.Add(tasksList);
            return tasksList;
        }

        public List<Task> GetTaskList(int listId)
        {
            return listOfTasksLists[listId - 1];
        }

        public Task CreateTask(int listId, Task item)
        {
            item.id = ++listOfTasksLists[listId - 1].lastTaskId;
            listOfTasksLists[listId - 1].Add(item);
            return item;
            // return Created($"tasks/{item.id}", item);
        }

        public Task GetTask(int listId, int taskId)
        {
            return listOfTasksLists[listId - 1][taskId -1];
        }

        public Task ReplaceTask(int listId, int taskId, Task item)
        {
            listOfTasksLists[listId - 1].RemoveAt(taskId - 1);
            item.id = taskId;
            listOfTasksLists[listId - 1].Add(item);
            return item;
        }
        // public Task Patch(int id, Task item)
        // {
        //     id =- 1;
        //     if(item.description != tasksList[id].description)
        //         tasksList[id].description = item.description;

        //     if(item.title != tasksList[id].title)
        //         tasksList[id].title = item.title;

        //     if(item.dueDate != tasksList[id].dueDate)
        //         tasksList[id].dueDate = item.dueDate;

        //     if(item.done != tasksList[id].done)
        //         tasksList[id].done = item.done;

        //     return tasksList[id];
        // }

        public void DeleteTask(int listId, int taskId)
        {
            listOfTasksLists[listId - 1].RemoveAt(taskId - 1); 
        }

        public List<IndexTaskList> GetAll()
        {
            List<IndexTaskList> list = new List<IndexTaskList>(); 
            foreach(var item in listOfTasksLists)
            {
                list.Add(new IndexTaskList(){title = item.title, id = item.id});
            }
            return list;
        }
    }
}