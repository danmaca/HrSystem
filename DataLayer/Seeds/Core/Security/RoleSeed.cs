using Havit.Data.Patterns.DataSeeds;
using DanM.HrSystem.Model.Security;
using DanM.HrSystem.Primitives.Security;

namespace DanM.HrSystem.DataLayer.Seeds.Core.Security;

public class RoleSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var roles = Enum.GetValues<RoleEntry>().Select(entry => new Role { Id = (int)entry, Name = entry.ToString() }).ToArray();

		Seed(For(roles).PairBy(r => r.Id));
	}
}
