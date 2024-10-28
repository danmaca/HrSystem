
namespace DanM.HrSystem.Services.Common;

public class ResultInfo
{
	private List<ResultMessage> _messages;
	public List<ResultMessage> Messages
	{
		get
		{
			if (_messages == null)
				_messages = new List<ResultMessage>();
			return _messages;
		}
	}

	public bool IsValid
	{
		get
		{
			return _messages?.Any(obj => obj.IsValid == false) != true;
		}
	}

	public void AddError(string text)
	{
		this.Messages.Add(new ResultMessage(ResultMessageType.Error, text));
	}

	public void AddResult(ResultInfo result)
	{
		this.Messages.AddRange(result.Messages);
	}
}

public class ResultMessage
{
	public ResultMessageType Type { get; set; }
	public string Text { get; set; }
	public bool IsValid => this.Type != ResultMessageType.Error;

	public ResultMessage()
	{
		this.Type = ResultMessageType.Success;
	}
	public ResultMessage(ResultMessageType type, string text)
	{
		this.Type = type;
		this.Text = text;
	}
}

public enum ResultMessageType
{
	Success,
	Warning,
	Error,
}