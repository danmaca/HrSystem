using MimeKit;

namespace DanM.HrSystem.Services.Mailing;

public interface IMailingService
{
	Task VerifyHealthAsync(CancellationToken cancellationToken = default);

	Task SendAsync(MimeMessage mailMessage, CancellationToken cancellationToken = default);
}
