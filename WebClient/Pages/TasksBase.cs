using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebClient.Abstractions;
using Domain.ViewModel;
using Domain.Queries;
namespace WebClient.Pages
{
	public class TasksBase : ComponentBase
	{
		[Inject]
		public ITaskDataService TaskDataService { get; set; }
		[Inject]
		public IMemberDataService MemberDataService { get; set; }
		
	}
}
