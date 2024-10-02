using DanM.HrSystem.Model.Employees;
using DanM.HrSystem.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Facades.ModelDescriptors;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class EmployeeDescriptor : EntityDescriptor<Employee>, IEmployeeDescriptor
{
	public StringProperty FirstNameProp { get; set; } = new StringProperty(() => "Jméno");
	public StringProperty LastNameProp { get; set; } = new StringProperty(() => "Příjmení");
}

public interface IEmployeeDescriptor
{
	StringProperty FirstNameProp { get; set; }
	StringProperty LastNameProp { get; set; }
}