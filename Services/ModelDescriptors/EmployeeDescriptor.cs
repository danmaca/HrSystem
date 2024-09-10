using DanM.HrSystem.Model.Employees;
using DanM.HrSystem.Services.Framework.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.HrSystem.Facades.ModelDescriptors;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class EmployeeDescriptor : EntityDescriptor<Employee>, IEmployeeDescriptor
{
	public StringProperty FirstName { get; set; } = new StringProperty();
	public StringProperty LastName { get; set; } = new StringProperty();
}

public interface IEmployeeDescriptor
{
	StringProperty FirstName { get; set; }
	StringProperty LastName { get; set; }
}