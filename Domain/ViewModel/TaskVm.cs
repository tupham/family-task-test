using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataModels;

namespace Domain.ViewModel
{
	public class TaskVm
	{
		public Guid Id { get; set; }
		public string Subject { get; set; }
		public Boolean IsComplete { get; set; }
		public Guid AssignedToId { get; set; }

		public Member Member { get; set; }

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Subject: {0}\n", this.Subject);
			stringBuilder.AppendFormat("IsComplete: {0}\n", this.IsComplete);
			if (this.Member != null)
			{
				stringBuilder.AppendFormat("Member: {0}\n", this.Member.Id);
				stringBuilder.AppendFormat("Member: {0}\n", this.Member.FirstName);
				stringBuilder.AppendFormat("Member: {0}\n", this.Member.LastName);
			}
			return stringBuilder.ToString();
		}
	}
}
