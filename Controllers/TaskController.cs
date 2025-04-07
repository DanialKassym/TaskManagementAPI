using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{


    [ApiController]
    [Route("Task")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TaskContext _context;

        public TaskController(ILogger<TaskController> logger, TaskContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<MyTasks> GetAll()
        {
            var tasks = _context.tasks.ToList();
            return tasks;
        }

        [HttpGet("{id}")]
        public MyTasks GetByid(long id)
        {
            var task = _context.tasks
                    .Where(t => t.Id == id)
                    .FirstOrDefault()
                    ;
            return task;
        }

        [HttpPost]
        public async Task<MyTasks> Addnew(MyTasks task)
        {

            _context.tasks.Add(task);

            await _context.SaveChangesAsync();

            return task;

        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var task = await _context.tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPatch("{id}")]
        public async Task<MyTasks> Update(int id, MyTasks task)
        {
            var updatetask = await _context.tasks.FindAsync(id);

            if (task == null)
            {
                return null;
            }

            task.name = task.name;
            task.status = task.status;

            await _context.SaveChangesAsync();

            return task;
        }

    }
}
