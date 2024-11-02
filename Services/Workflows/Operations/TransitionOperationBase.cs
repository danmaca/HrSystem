namespace DanM.Core.Services.Workflows.Operations;

public abstract class TransitionOperationBase
{
	public void RunOperation(RunTransitionResult runResult)
	{
		this.OnRunOperation(runResult);
	}

	protected abstract void OnRunOperation(RunTransitionResult runResult);
}
