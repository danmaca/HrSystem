using DanM.HrSystem.Model.Employees;
using DanM.Core.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Facades.ModelDescriptors.Employees;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class EmployeeListFilterDescriptor : EntityDescriptor<Employee>, IEmployeeListFilterDescriptor
{
	public StringProperty NameLike { get; set; } = new StringProperty(() => "Jméno");
}

public interface IEmployeeListFilterDescriptor
{
	StringProperty NameLike { get; set; }
}