namespace DanM.HrSystem.Services.Jobs;

public interface IRunnableJob
{
	Task ExecuteAsync(CancellationToken cancellationToken);
}
