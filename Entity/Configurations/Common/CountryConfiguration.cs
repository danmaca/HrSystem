﻿using DanM.HrSystem.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanM.HrSystem.Entity.Configurations.Common;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.HasIndex(c => c.IsoCode).IsUnique();
		builder.HasIndex(c => c.IsoCode3).IsUnique();
	}
}
