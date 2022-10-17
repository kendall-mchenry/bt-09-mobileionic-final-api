using final_task_api.Models;
using final_task_api.Migrations;
using final_task_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = final_task_api.Models.Task;

namespace final_task_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TasksController : ControllerBase 
{
    private readonly ILogger<TasksController> _logger;

    private readonly ITasksRepository _taskRepository;

    public TasksController(ILogger<TasksController> logger, ITasksRepository repository) {
        _logger = logger;
        _taskRepository = repository;
    }

    // POST / create new task
    [HttpPost]
    public ActionResult<Task> CreateTask(Task task) 
    {
        if (!ModelState.IsValid || task == null) {
            return BadRequest();
        }

        var newTask = _taskRepository.CreateTask(task);

        return Created(nameof(GetTaskById), newTask);
    }

    // GET / get one task by id
    [HttpGet]
    [Route("{taskId:int}")]
    public ActionResult<Task> GetTaskById(int taskId) 
    {
        var task = _taskRepository.GetTaskById(taskId);

        if (task == null) {
            return NotFound();
        }

        return Ok(task);
    }

    // GET / all tasks
    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetTasks()
    {
        return Ok(_taskRepository.GetAllTasks());
    }

    // PUT / edit task by id
    [HttpPut]
    [Route("edit/{taskId:int}")]
    public ActionResult<Task> EditTask(Task editTask)
    {
        if (!ModelState.IsValid || editTask == null) {
            return BadRequest();
        }

        return Ok(_taskRepository.EditTask(editTask));
    }

    // DELETE / delete task by id
    [HttpDelete]
    [Route("{taskId:int}")]
    public ActionResult DeleteTask(int taskId) 
    {
        _taskRepository.DeleteTaskById(taskId);
        
        return NoContent();
    }
}