﻿using Havit.Data.EntityFrameworkCore.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DanM.HrSystem.Model.Security;

[Cache(Priority = CacheItemPriority.High)]
public class Role
{
	public int Id { get; set; }

	[MaxLength(255)]
	public string Name { get; set; }
}
