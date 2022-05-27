﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AppTodo.Api.Controllers;
using AppTodo.Application.Commands;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Application.Commands.Handlers.CreateTodo;
using AppTodo.Application.Commands.Handlers.MarkTodoAsDone;
using AppTodo.Core.Entities;
using AppTodo.Core.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTodo.Api.V1.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/Todo")]
  [Authorize]
  public class TodoController : MainController
  {
    public readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>return a list of tasks. </returns>
    [Route("getall")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> GetAll()
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      var result = await _todoRepository.GetAll(user);
      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Get all tasks are done.
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are done.</returns>
    [Route("getalldone")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetAllDone()
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetAllDone(user);
      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Get all tasks are undone.
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are done.</returns>
    [Route("getallundone")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetAllUndone()
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetAllUndone(user);
      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Get all tasks are undone for today.
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are undone for today</returns>
    [Route("undone/today")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetUndoneForToday()
    {

      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetByPeriod(
        user,
        DateTime.Now.Date,
        false
        );

      if (result is null)
        return BadRequest(result);

      return Ok(result);

    }

    /// <summary>
    /// Get all tasks are done for today.
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are undone for today</returns>
    [Route("done/today")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetDoneForToday()
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetByPeriod(
        user,
        DateTime.Now.Date,
        true
        );

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Get all tasks are done for tomorrow
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are undone for tomorrow</returns>
    [Route("done/tomorrow")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetDoneForTomorrow()
    {

      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetByPeriod(
       user,
        DateTime.Now.Date.AddDays(1),
        true
        );

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Get all tasks are undone for tomorrow
    /// </summary>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return all tasks are undone for tomorrow</returns>
    [Route("undone/tomorrow")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> GetUndoneForTomorrow()
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

      var result = await _todoRepository.GetByPeriod(
        user,
        DateTime.Now.Date.AddDays(1),
        false
        );

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Create new Tasks.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return new task creat</returns>
    [Route("create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> Create([FromBody] CreateTodoCommand command, [FromServices] IHandler<CreateTodoCommand> handler)
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      command.User = user;

      var result = await handler.Handle(command) as GenericCommandResult;

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Update tasks title.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return task update.</returns>
    [Route("update")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> Update([FromBody] UpdateTodoCommand command, [FromServices] IHandler<UpdateTodoCommand> handler)
    {

      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      command.User = user;

      var result = await handler.Handle(command) as GenericCommandResult;

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Mark tasks with done.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return task that mark with done</returns>
    [Route("markasdone")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] IHandler<MarkTodoAsDoneCommand> handler)
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      command.User = user;

      var result = await handler.Handle(command) as GenericCommandResult;

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }

    /// <summary>
    /// Mark tasks with undone.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="handler"></param>
    /// <response code="200">The request was fulfilled.</response>
    /// <response code="400">The request wasn't processed.</response>
    /// <returns>Return task that mark with undone</returns>
    [Route("markasundone")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItem>> MarkAsUnDone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] IHandler<MarkTodoAsUndoneCommand> handler)
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      command.User = user;

      var result = await handler.Handle(command) as GenericCommandResult;

      if (result is null)
        return BadRequest(result);

      return Ok(result);
    }
  }
}
