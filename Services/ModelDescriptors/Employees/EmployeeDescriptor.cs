﻿using DanM.HrSystem.Model.Employees;
using DanM.Core.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Facades.ModelDescriptors.Employees;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class EmployeeDescriptor : EntityDescriptor<Employee>, IEmployeeDescriptor
{
	public StringProperty FirstName { get; set; } = new StringProperty(() => "Jméno");
	public StringProperty LastName { get; set; } = new StringProperty(() => "Příjmení");
	public StringProperty PersonalNumber { get; set; } = new StringProperty(() => "Osobní číslo");
}

public interface IEmployeeDescriptor
{
	StringProperty FirstName { get; set; }
	StringProperty LastName { get; set; }
	StringProperty PersonalNumber { get; set; }
}