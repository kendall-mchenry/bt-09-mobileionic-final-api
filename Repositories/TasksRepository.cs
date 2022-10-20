using final_task_api.Migrations;
using final_task_api.Models;
using Task = final_task_api.Models.Task;

namespace final_task_api.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly TasksDbContext _context;

    public TasksRepository(TasksDbContext context) {
        _context = context;
    }

    // POST / create new task 
    public Task CreateTask(Task newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    // DELETE / delete tasks by id
    public void DeleteTaskById(int taskId)
    {
        var deleteTask = _context.Tasks.Find(taskId);

        if (deleteTask != null) {
            _context.Tasks.Remove(deleteTask);
            _context.SaveChanges();
        }
    }

    // PUT / edit task by id
    public Task? EditTask(Task editTask)
    {
        var originalTask = _context.Tasks.Find(editTask.TaskId);

        if (originalTask != null) {
            originalTask.TaskTitle = editTask.TaskTitle;
            originalTask.TaskCompleted = editTask.TaskCompleted;
            _context.SaveChanges();
        }

        return originalTask;
    }

    // GET / get all tasks
    public IEnumerable<Task> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }

    // I MAY NOT NEED THIS ONE
    // GET / get task by id
    public Task? GetTaskById(int taskId)
    {
        return _context.Tasks.SingleOrDefault(t => t.TaskId == taskId);
    }
}