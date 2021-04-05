using System;
using System.Collections.Generic;

namespace webapi
{
    public class  TasksListService
    {
        private Dictionary<int, TasksService> listOfTasksLists = new Dictionary<int, TasksService>();

        public TasksListService()
        {
            listOfTasksLists.Add(1, new TasksService() {name = "Home work."}); 
            listOfTasksLists.Add(2, new TasksService() {name = "Home work2."});
            listOfTasksLists.Add(3, new TasksService() {name = "Home work3."});  
        }
        
        public Dictionary<int, TasksService> GetDict()
        {
            return listOfTasksLists;
        }

        public List<TasksList> GetAll()
        {
            List<TasksList> list = new List<TasksList>(); 
            foreach(var item in listOfTasksLists)
            {
                list.Add(new TasksList() {title = item.Value.name, id = item.Key});
            }
            return list;
        }

        public List<Task> GetOne(int listId)
        {
            return listOfTasksLists[listId].GetAll();
        }
    }
}