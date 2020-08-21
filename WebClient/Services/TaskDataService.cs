using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Domain.Commands;
using WebClient.Abstractions;
using Domain.Queries;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
namespace WebClient.Services
{
	public class TaskDataService : ITaskDataService
	{
		private HttpClient _httpClient;
		public TaskDataService(HttpClient httpClient)
		{
			this._httpClient = httpClient;
		}

		public async Task<CreateTaskCommandResult> Create(CreateTaskCommand command)
		{
			return await _httpClient.PostJsonAsync<CreateTaskCommandResult>("tasks", command);
		}

		public async Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command)
		{
			return await this._httpClient.PutJsonAsync<UpdateTaskCommandResult>("tasks/"+command.Id, command);
		}

		public async Task<HttpResponseMessage> Delete(DeleteTaskCommand command)
		{
			return await _httpClient.DeleteAsync("tasks/"+command.Id);
		}

		public async Task<GetAllTasksQueryResult> GetAllTasks()
		{
			return await _httpClient.GetJsonAsync<GetAllTasksQueryResult>("tasks");
		}
	}
}
