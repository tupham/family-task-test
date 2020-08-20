using System;
using System.Text;
public class FamilyMember
{
    public Guid id {get; set;}
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string role { get; set; }
    public string avtar { get; set; }

	public override string ToString()
	{
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("firstname: {0}, lastname: {1}", this.firstname, this.lastname);
        return stringBuilder.ToString();
	}
}
