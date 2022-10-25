namespace WebAPI.Controllers;

using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoLogic todoLogic;

    public TodosController(ITodoLogic todoLogic)
    {
        this.todoLogic = todoLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> CreateAsync([FromBody] TodoCreationDto dto)
    {
        try
        {
            Todo created = await todoLogic.CreateAsync(dto);
            return Created($"/todos/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
        [FromQuery] bool? completedStatus, [FromQuery] string? titleContains)
    {
        try
        {
            SearchTodoParametersDto parameters = new(userName, userId, completedStatus, titleContains);
            var todos = await todoLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] TodoUpdateDto dto)
    {
        try
        {
            await todoLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await todoLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    //The id sub-part of the URI is passed as the argument, because the argument is marked [FromRoute],
    //meaning this argument is found in the URI.
    //The argument variable must be named the same as in the URI template, i.e. "id".
}