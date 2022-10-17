using final_task_api.Models;
using Task = final_task_api.Models.Task;

namespace final_task_api.Repositories;

public interface ITasksRepository
{
    IEnumerable<Task> GetAllTasks();

    Task? GetTaskById(int taskId);

    Task CreateTask(Task newTask);

    Task? EditTask(Task editTask);

    void DeleteTaskById(int taskId);

}