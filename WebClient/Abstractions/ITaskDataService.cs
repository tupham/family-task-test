using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Queries;
using System.Net.Http;
namespace WebClient.Abstractions
{
	public interface ITaskDataService
	{
		public Task<CreateTaskCommandResult> Create(CreateTaskCommand command);

		public Task<GetAllTasksQueryResult> GetAllTasks();

		public Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command);

		public Task<HttpResponseMessage> Delete(DeleteTaskCommand command);
	}
}
