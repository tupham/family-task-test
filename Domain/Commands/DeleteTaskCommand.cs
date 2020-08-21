﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
	public class DeleteTaskCommand
	{
		public Guid Id { get; set; }
		public string Subject { get; set; }
		public Boolean IsComplete { get; set; }

		public Guid AssignedToId { get; set; }
	}
}
