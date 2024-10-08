﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DanM.HrSystem.Entity;

public class HrSystemDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HrSystemDbContext>
{
	public HrSystemDbContext CreateDbContext(string[] args)
	{
		// Commands EF Core Migrations (Add-Migration, ...) tooling get DbContext from this method. (+ CodeGenerator)
		// InMemory provider cannot be used for EF Core Migrations tooling, SqlServer provider has to be used.
		string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

		// Current path is for CodeGenerator DataLayer
		// We need to read Entity configuration, Entity\bin\Debug(Release)\nestandard2.0.
		IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location))
			.AddJsonFile("appSettings.Entity.json")
			.AddJsonFile($"appSettings.Entity.{environment}.json", true)
			.AddJsonFile($"appSettings.Entity.{environment}.local.json", true) // .gitignored
			.Build();

		string connectionString = configuration.GetConnectionString("Database");

		return new HrSystemDbContext(new DbContextOptionsBuilder<HrSystemDbContext>().UseSqlServer(connectionString).Options);
	}
}
