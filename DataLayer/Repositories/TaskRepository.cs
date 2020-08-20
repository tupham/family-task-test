using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
	public class TaskRepository : BaseRepository<Guid, Domain.DataModels.Task, TaskRepository>, ITaskRepository
	{

        public TaskRepository(FamilyTaskContext context) : base(context)
        { 
        }

		public async Task<List<Domain.DataModels.Task>> GetAllTasks()
		{
            var result = await this.Query.Include(x => x.Member).ToListAsync();
            return result;
		}

        public override async Task<Domain.DataModels.Task> CreateRecordAsync(Domain.DataModels.Task record, CancellationToken cancellationToken = default)
        {
            var result = await Context.AddAsync(record, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            var taskModel = result.Entity;
            return await Query.Include(x => x.Member).FirstOrDefaultAsync(x => x.Id == taskModel.Id);

        }

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        ITaskRepository IBaseRepository<Guid, Domain.DataModels.Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }


    }
}
