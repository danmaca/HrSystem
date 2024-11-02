namespace DanM.Core.Contracts.ControlDatas;

public class ActionButtonDto
{
	public string UniqueKey => (this.OwnerIdent ?? "") + this.Key;
	public string Key { get; set; }
	public string OwnerIdent { get; set; }
	public string Text { get; set; }
}