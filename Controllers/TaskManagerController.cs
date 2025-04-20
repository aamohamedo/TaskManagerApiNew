using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TasManager.API.Controller
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskManagerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TaskManagerController(AppDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Retrieves all tasks from the database.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _db.Tasks.ToListAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Retrieves a specific task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return NotFound("Task not found");

            return Ok(task);
        }

        /// <summary>
        /// Creates a new task and stores it in the database.
        /// </summary>
        /// <param name="Task">The task object to be created.</param>
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskItemModel Task)
        {
            if (Task == null)
                return BadRequest("Task cannot be null");

            if (!ModelState.IsValid)
                return BadRequest("Please enter a task");

            if (string.IsNullOrEmpty(Task.Title))
                return BadRequest("Please enter a title");

            if (string.IsNullOrEmpty(Task.Status))
                return BadRequest("Please enter a status");

            if (Task.DueDate == DateTime.MinValue)
                return BadRequest("Please enter a due date");

            if (Task.DueDate < DateTime.Now)
                return BadRequest("Due date cannot be in the past");

            if (Task.DueDate == null)
                Task.DueDate = DateTime.Now;

            var newTask = new TaskItemModel
            {
                Title = Task.Title,
                Description = Task.Description,
                Status = Task.Status,
                DueDate = Task.DueDate.Value
            };

            _db.Tasks.Add(newTask);

            await _db.SaveChangesAsync();

            return Ok(new { message = $"Task with ID {newTask.Id} added successfully." });
        }

        /// <summary>
        /// Deletes a task from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return BadRequest($"Task with id {id} doesnt exist");

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();

            return Ok(new { message = $"Task with ID {id} has been deleted." });
        }

        /// <summary>
        /// Updates an existing task with new values.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="updatedTaskItem">The updated task data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskItemModel updatedTaskItem)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return NotFound(new { message = $"Task with ID {id} doesn't exist" });

            if (!string.IsNullOrWhiteSpace(updatedTaskItem.Status) && updatedTaskItem.Status != "string")
                task.Status = updatedTaskItem.Status;

            if (!string.IsNullOrWhiteSpace(updatedTaskItem.Description) && updatedTaskItem.Description != "string")
                task.Description = updatedTaskItem.Description;

            if (!string.IsNullOrWhiteSpace(updatedTaskItem.Title) && updatedTaskItem.Title != "string")
                task.Title = updatedTaskItem.Title;

            if (updatedTaskItem.DueDate != null && updatedTaskItem.DueDate != DateTime.MinValue)
                task.DueDate = updatedTaskItem.DueDate.Value;

            await _db.SaveChangesAsync();

            return Ok(new { message = $"Task with ID {id} updated successfully." });
        }
    }
}