using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.DataModels
{
	public class Task
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Subject { get; set; }
		public Boolean IsComplete { get; set; }
		
		public Guid AssignedToId { get; set; }

		[ForeignKey("AssignedToId")]
		public Member Member { get; set; }
	}
}
