using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.Queries;
using Domain.ViewModel;
namespace Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _taskRepository;
		private readonly IMapper _mapper;
		public TaskService(IMapper mapper, ITaskRepository taskRepository)
		{
			this._taskRepository = taskRepository;
			this._mapper = mapper;
		}
		public async Task<CreateTaskCommandResult> CreateTaskCommandHandler(CreateTaskCommand command)
		{
			Console.WriteLine("Subject: {0}, IsComplete: {1}, AssignedToId: {2}",command.Subject, command.IsComplete, command.AssignedToId);
			
			var task = _mapper.Map<Domain.DataModels.Task>(command);
			var persistedTask = await this._taskRepository.CreateRecordAsync(task);
			var vm = _mapper.Map<TaskVm>(persistedTask);

			return new CreateTaskCommandResult()
			{
				Payload = vm
			};
		}

		public async Task<UpdateTaskCommandResult> UpdateTaskCommandHandler(UpdateTaskCommand command)
		{
			var isSucceed = true;
			var task = await this._taskRepository.ByIdAsync(command.Id);

			_mapper.Map<UpdateTaskCommand, Domain.DataModels.Task>(command, task);

			var affectedRecordsCount = await this._taskRepository.UpdateRecordAsync(task);

			if (affectedRecordsCount < 1)
				isSucceed = false;

			return new UpdateTaskCommandResult()
			{
				Succeed = isSucceed
			};
		}

		public async Task<DeleteTaskCommandResult> DeleteTask(Guid id)
		{			
			var result = await this._taskRepository.DeleteRecordAsync(id);
			return new DeleteTaskCommandResult() { Succeed = result!=0};
		}

		public async Task<GetAllTasksQueryResult> GetAllTasksQueryHandler()
		{
			IEnumerable<TaskVm> vm = new List<TaskVm>();

			var tasks = await this._taskRepository.GetAllTasks();

			if (tasks != null && tasks.Any())
			{
				vm = _mapper.Map<IEnumerable<TaskVm>>(tasks);
				foreach(var item in vm)
				{
					Console.WriteLine(item.ToString());
				}
			}
			return new GetAllTasksQueryResult()
			{
				Payload = vm
			};
		}
	}
}
