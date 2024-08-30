using Havit.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanM.HrSystem.Entity;

public class HrSystemDbContext : Havit.Data.EntityFrameworkCore.DbContext
{
	/// <summary>
	/// Constructor for unit tests.
	/// </summary>
	internal HrSystemDbContext()
	{
		// NOOP
	}

	public HrSystemDbContext(DbContextOptions options) : base(options)
	{
		// NOOP
	}

	/// <inheritdoc />
	protected override void CustomizeModelCreating(ModelBuilder modelBuilder)
	{
		base.CustomizeModelCreating(modelBuilder);

		// modelBuilder.HasSequence<int>("XySequence");

		modelBuilder.RegisterModelFromAssembly(typeof(DanM.HrSystem.Model.Localizations.Language).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
	}
}
