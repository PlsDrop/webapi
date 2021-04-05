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
    [Route("/lists")]
    public class TasksController : ControllerBase
    {
        private TasksService tasksService;
        private TasksListService tasksListService;

        public TasksController(TasksService taskService, TasksListService tasksListService)
        {
           this.tasksService = taskService;
           this.tasksListService = tasksListService;
        }

        [HttpGet("/lists")]
        public List<(int, string)> GetAllLists()
        {
            return tasksListService.GetAll();
        }
        

        [HttpGet("/lists/{listId}/tasks")]
        public IEnumerable<Task> GetList(int listId)
        {
            return tasksListService.GetOne(listId); 
        }
       
        [HttpGet("/lists/{listId}/tasks/{taskId}")]
        public Task GetTask(int listId, int taskId)
        {
            return tasksListService.GetDict()[listId].Get(taskId);
        }
        
        [HttpPost("/lists/{listId}/tasks")]
        public ActionResult<Task> AddTask(int listId, Task task)
        {   
            Task createdTask = tasksListService.GetDict()[listId].Create(task);  //tasksService.Create(task);
            return Created($"/lists/{listId}/tasks/{createdTask.id}", createdTask);
        }

        [HttpPut("/lists/{listId}/tasks/{taskId}")]
        public ActionResult<Task> ReplaceTask(int listId, int taskId, Task task)
        {
            Task createdTask = tasksListService.GetDict()[listId].Replace(taskId, task); //tasksService.Replace(taskId, task);
            return Created($"/lists/{listId}/tasks/{createdTask.id}", createdTask);
        }

        [HttpPatch("/lists/{listId}/tasks/{taskId}")]
        public ActionResult<Task> PatchTask(int listId, int taskId, Task task)
        {
            Task updatedTask = tasksListService.GetDict()[listId].Patch(taskId, task); //tasksService.Patch(taskId, task);
            return Created($"/lists/{listId}/tasks/{updatedTask.id}", updatedTask);
        }

        [HttpDelete("/lists/{listId}/tasks/{taskId}")]
        public ActionResult DeleteTask(int listId, int taskId)
        {
            tasksListService.GetDict()[listId].Delete(taskId); //tasksService.Delete(taskId);
            return Ok($"Deleted: /lists/{listId}/tasks/{taskId}");
        }
    }
}
