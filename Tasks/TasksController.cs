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
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private TasksService tasksService;

        public TasksController(TasksService service)
        {
           this.tasksService = service;
        }

        [HttpGet("")]
        public IEnumerable<Task> GetTasks()
        {
            return tasksService.GetAll();
        }
       
        [HttpGet("/Tasks/{taskId}")]
        public Task GetTask(int taskId)
        {
            return tasksService.Get(taskId);
        }
        
        [HttpPost("")]
        public ActionResult<Task> AddTask(Task task)
        {
            Task createdTask = tasksService.Create(task);
            return Created($"tasks/{createdTask.id}", createdTask);
        }

        [HttpPut("/Tasks/{taskId}")]
        public ActionResult<Task> ReplaceTask(int taskId, Task task)
        {
            Task createdTask = tasksService.Replace(taskId, task);
            return Created($"tasks/{createdTask.id}", createdTask);
        }

        [HttpPatch("/Tasks/{taskId}")]
        public ActionResult<Task> PatchTask(int taskId, Task task)
        {
            Task updatedTask = tasksService.Patch(taskId, task);
            return Created($"tasks/{updatedTask.id}", updatedTask);
        }

        [HttpDelete("/Tasks/{taskId}")]
        public ActionResult DeleteTask(int taskId, Task task)
        {
            tasksService.Delete(taskId);
            return Ok($"Deleted: /Tasks/{taskId}");
        }
    }
}
