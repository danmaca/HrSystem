using DanM.HrSystem.Model.Employees;
using DanM.Core.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Facades.ModelDescriptors;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class EmployeeDescriptor : EntityDescriptor<Employee>, IEmployeeDescriptor
{
	public StringProperty FirstName { get; set; } = new StringProperty(() => "Jméno");
	public StringProperty LastName { get; set; } = new StringProperty(() => "Příjmení");
}

public interface IEmployeeDescriptor
{
	StringProperty FirstName { get; set; }
	StringProperty LastName { get; set; }
}