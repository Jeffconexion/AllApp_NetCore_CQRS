using System;
using System.Threading.Tasks;
using AppTodo.Application.Commands;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Application.Commands.Handlers.CreateTodo;
using AppTodo.Application.Commands.Handlers.MarkTodoAsDone;
using AppTodo.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AppTodo.Api.Controllers
{
  [ApiController]
  [Route("v1/todos")]
  public class TodoController : ControllerBase
  {
    public readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <returns></returns>
    [Route("getall")]
    [HttpGet]
    public async Task<object> GetAll()
    {
      var result = await _todoRepository.GetAll("Jefferson");
      return result;
    }

    /// <summary>
    /// Get all tasks are done.
    /// </summary>
    /// <returns></returns>
    [Route("getalldone")]
    [HttpGet]
    public async Task<object> GetAllDone()
    {
      var result = await _todoRepository.GetAllDone("Jefferson");
      return result;
    }

    /// <summary>
    /// Get all tasks are undone.
    /// </summary>
    /// <returns></returns>
    [Route("getallundone")]
    [HttpGet]
    public async Task<object> GetAllUndone()
    {
      var result = await _todoRepository.GetAllUndone("Jefferson");
      return result;
    }

    /// <summary>
    /// Get all tasks are undone for today.
    /// </summary>
    /// <returns></returns>
    [Route("undone/today")]
    [HttpGet]
    public async Task<object> GetUndoneForToday()
    {
      var result = await _todoRepository.GetByPeriod(
        "Jefferson",
        DateTime.Now.Date,
        false
        );
      return result;
    }

    /// <summary>
    /// Get all tasks are done for today.
    /// </summary>
    /// <returns></returns>
    [Route("done/today")]
    [HttpGet]
    public async Task<object> GetDoneForToday()
    {
      var result = await _todoRepository.GetByPeriod(
        "Jefferson",
        DateTime.Now.Date,
        true
        );
      return result;
    }

    /// <summary>
    /// Get all tasks are done for tomorrow
    /// </summary>
    /// <returns></returns>
    [Route("done/tomorrow")]
    [HttpGet]
    public async Task<object> GetDoneForTomorrow()
    {
      var result = await _todoRepository.GetByPeriod(
        "Jefferson",
        DateTime.Now.Date.AddDays(1),
        true
        );
      return result;
    }

    /// <summary>
    /// Get all tasks are undone for tomorrow
    /// </summary>
    /// <returns></returns>
    [Route("undone/tomorrow")]
    [HttpGet]
    public async Task<object> GetUndoneForTomorrow()
    {
      var result = await _todoRepository.GetByPeriod(
        "Jefferson",
        DateTime.Now.Date.AddDays(1),
        false
        );
      return result;
    }

    /// <summary>
    /// Create new Tasks.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    [Route("create")]
    [HttpPost]
    public async Task<GenericCommandResult> Create([FromBody] CreateTodoCommand command, [FromServices] IHandler<CreateTodoCommand> handler)
    {
      GenericCommandResult result = await handler.Handle(command) as GenericCommandResult;
      return result;
    }

    /// <summary>
    /// Update tasks if there is.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    [Route("update")]
    [HttpPut]
    public async Task<GenericCommandResult> Update([FromBody] UpdateTodoCommand command, [FromServices] IHandler<UpdateTodoCommand> handler)
    {
      GenericCommandResult result = await handler.Handle(command) as GenericCommandResult;
      return result;
    }

    /// <summary>
    /// Mark tasks with done.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    [Route("markasdone")]
    [HttpPut]
    public async Task<GenericCommandResult> MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] IHandler<MarkTodoAsDoneCommand> handler)
    {
      GenericCommandResult result = await handler.Handle(command) as GenericCommandResult;
      return result;
    }

    /// <summary>
    /// Mark tasks with undone.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    [Route("markasundone")]
    [HttpPut]
    public async Task<GenericCommandResult> MarkAsUnDone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] IHandler<MarkTodoAsUndoneCommand> handler)
    {
      GenericCommandResult result = await handler.Handle(command) as GenericCommandResult;
      return result;
    }
  }
}
