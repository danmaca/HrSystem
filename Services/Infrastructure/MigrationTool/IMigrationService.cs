namespace DanM.Core.Services.Infrastructure.MigrationTool;

public interface IMigrationService
{
	Task UpgradeDatabaseSchemaAndDataAsync(CancellationToken cancellationToken = default);
}