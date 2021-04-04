using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
