using DanM.HrSystem.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanM.HrSystem.Entity.Configurations.Security;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder.Property(a => a.Id).ValueGeneratedNever();
	}
}
