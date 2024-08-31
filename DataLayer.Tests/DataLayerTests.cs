using DanM.HrSystem.DataLayer.DataSources.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanM.HrSystem.Entity;
using Havit.Data.EntityFrameworkCore.Patterns.SoftDeletes;
using Havit.Services.TimeServices.Fakes;

namespace DanM.HrSystem.DataLayer.Tests;

[TestClass]
public class DataLayerTests
{
	[TestMethod]
	public void DataLayerTests_CheckLoad()
	{
		// Arrange
		DbContextOptions<HrSystemDbContext> options = new DbContextOptionsBuilder<HrSystemDbContext>()
			.UseInMemoryDatabase(nameof(HrSystemDbContext))
			.Options;
		HrSystemDbContext dbContext = new HrSystemDbContext(options);

		// Act
		Havit.Data.EntityFrameworkCore.ModelValidation.ModelValidator modelValidator = new Havit.Data.EntityFrameworkCore.ModelValidation.ModelValidator();
		string errors = modelValidator.Validate(dbContext);

		// Assert
		if (!String.IsNullOrEmpty(errors))
		{
			Assert.Fail(errors);
		}

		var pers = new EmployeeDbDataSource(dbContext, new SoftDeleteManager(new FakeTimeService(DateTime.Now)));
		var d = pers.Data;
	}
}
