using Havit.Services.FileStorage;

namespace DanM.HrSystem.Services.Infrastructure.FileStorages;

public class ApplicationFileStorageService : FileStorageWrappingService<ApplicationFileStorage>, IApplicationFileStorageService
{
	public ApplicationFileStorageService(IFileStorageService<ApplicationFileStorage> fileStorageService) : base(fileStorageService)
	{
	}
}
