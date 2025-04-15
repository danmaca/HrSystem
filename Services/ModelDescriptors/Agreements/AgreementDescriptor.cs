using DanM.HrSystem.Model.Agreements;
using DanM.Core.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Facades.ModelDescriptors.Agreements;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class AgreementDescriptor : EntityDescriptor<Agreement>, IAgreementDescriptor
{
	public StringProperty Name { get; set; } = new StringProperty(() => "Jméno");
	public DateOnlyProperty ValidFrom { get; set; } = new DateOnlyProperty(() => "Platnost od");
	public DateOnlyProperty ValidTo { get; set; } = new DateOnlyProperty(() => "Platnost do");
}

public interface IAgreementDescriptor
{
	StringProperty Name { get; set; }
	DateOnlyProperty ValidFrom { get; set; }
	DateOnlyProperty ValidTo { get; set; }
}