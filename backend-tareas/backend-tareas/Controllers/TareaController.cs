using backend_tareas.Context;
using backend_tareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public TareaController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTareas()
    {
        try
        {
            var tareas = await _context.Tareas.ToListAsync();
            return Ok(tareas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    //Parseamos de Json a Object con la etiqueta [FromBody]
    public async Task<IActionResult> CreateTarea([FromBody] Tarea tarea)
    {
        if (tarea == null || string.IsNullOrWhiteSpace(tarea.Name))
        {
            return BadRequest("Invalid task data.");
        }

        try
        {
            tarea.Id = Guid.NewGuid();
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task created successfully", tarea });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTarea(Guid id, [FromBody] Tarea tarea)
    {
        try
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }
            tarea.State = !tarea.State;
            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task updated successfully", tarea});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarea(Guid id)
    {
        try
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound("Task not found.");
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task deleted successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}