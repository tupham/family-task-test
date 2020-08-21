using System;
using System.Text;
public class TaskModel
{
    public Guid id {get; set;}
    public FamilyMember member { get; set; }
    public string text { get; set; }
    public bool isDone { get; set; }

	public override string ToString()
	{
		var stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("id: {0}, text: {1}, isDone: {2}\n", this.id, this.text, this.isDone);
		if (member != null)
		{
			stringBuilder.AppendFormat("Member: id: {0}, first_name: {1}", this.member.id, this.member.firstname);
		}
		return stringBuilder.ToString();
	}
}
