using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
		private ITaskService _taskService;
		public TasksController(ITaskService taskService)
		{
			this._taskService = taskService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(CreateTaskCommandResult), StatusCodes.Status200OK)]
		public async Task<IActionResult> Create(CreateTaskCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await this._taskService.CreateTaskCommandHandler(command);

			return Created($"/api/tasks/{result.Payload.Id}", result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(UpdateTaskCommand), StatusCodes.Status200OK)]
		public async Task<IActionResult> Update(Guid id, UpdateTaskCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var result = await this._taskService.UpdateTaskCommandHandler(command);

				return Ok(result);
			}
			catch (NotFoundException<Guid>)
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(DeleteTaskCommandResult), StatusCodes.Status200OK)]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var result = await this._taskService.DeleteTask(id);

				return Ok(result);
			}
			catch (NotFoundException<Guid>)
			{
				return NotFound();
			}
		}

		[HttpGet]
		[ProducesResponseType(typeof(GetAllTasksQueryResult), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll()
		{
			var result = await this._taskService.GetAllTasksQueryHandler();

			return Ok(result);
		}
	}
}
