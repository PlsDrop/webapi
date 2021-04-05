using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace webapi
{
    [ApiController]
    [Route("/param")]
    public class TasksParamController : ControllerBase
    {
        private TasksListService tasksListService;

        public TasksParamController( TasksListService tasksListService)
        {
           this.tasksListService = tasksListService;
        }


        // [HttpGet("/param/tasks")]
        // public IEnumerable<IndexTaskList> GetAllLists()
        // {
        //     return tasksListService.GetAll();
        // }

        [HttpGet("/param/tasks")]
        public IEnumerable<Task> GetList()
        {   
            if (Request.Query.ContainsKey("listId"))
                {
                int listId = Int32.Parse(Request.Query["listId"]);
                return tasksListService.GetTaskList(listId); 
                }
            else
                return null;
        }

//         [HttpGet("/param/tasks")]
//         public Task GetTask()
//         {
//             int listId = Int32.Parse(Request.Query["listId"]);
//             int taskId = Int32.Parse(Request.Query["taskId"]);
//             return tasksListService.GetTask(listId, taskId);
//         }

//         [HttpPost("/param/tasks")]
//         public ActionResult<TaskList<Task>> AddList()
//         {   
//             TaskList<Task> createdList = tasksListService.CreateList(Request.Query["newListName"]);
//             return Created($"/lists/{createdList.id}", createdList);
//         }

//         [HttpPost("/param/tasks")]
//         public ActionResult<Task> AddTask(Task task)
//         {   
//             int listId = Int32.Parse(Request.Query["listId"]);
//             Task createdTask = tasksListService.CreateTask(listId, task);
//             return Created($"/lists/{listId}/tasks/{createdTask.id}", createdTask);
//         }

//         [HttpPut("/param/tasks")]
//         public ActionResult<Task> ReplaceTask(Task task)
//         {
//             int listId = Int32.Parse(Request.Query["listId"]);
//             int taskId = Int32.Parse(Request.Query["taskId"]);
//             Task createdTask = tasksListService.ReplaceTask(listId, taskId, task); //tasksService.Replace(taskId, task);
//             return Created($"/lists/{listId}/tasks/{createdTask.id}", createdTask);
//         }

//         [HttpDelete("/param/tasks")]
//         public ActionResult DeleteTask(Task task)
//         {
//             int listId = Int32.Parse(Request.Query["listId"]);
//             int taskId = Int32.Parse(Request.Query["taskId"]);
//             tasksListService.DeleteTask(listId, taskId); //tasksService.Delete(taskId);
//             return Ok($"Deleted: /lists/{listId}/tasks/{taskId}");
//         }

    }
}