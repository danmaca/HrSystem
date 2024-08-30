using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanM.HrSystem.Entity.Tests;

[TestClass]
public class HrSystemDbContextTests
{
	[TestMethod]
	public void HrSystemDbContext_CheckModelConventions()
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
	}
}
