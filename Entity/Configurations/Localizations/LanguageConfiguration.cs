﻿using DanM.HrSystem.Model.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanM.HrSystem.Entity.Configurations.Localizations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
	public void Configure(EntityTypeBuilder<Language> builder)
	{
		builder.Property(l => l.Id).ValueGeneratedNever();
	}
}
