﻿using MimeKit;

namespace DanM.Core.Services.Mailing;

public interface IMailingService
{
	Task VerifyHealthAsync(CancellationToken cancellationToken = default);

	Task SendAsync(MimeMessage mailMessage, CancellationToken cancellationToken = default);
}
