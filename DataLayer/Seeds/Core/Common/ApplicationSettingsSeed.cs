﻿using DanM.HrSystem.Model.Common;
using Havit.Data.Patterns.DataSeeds;

namespace DanM.HrSystem.DataLayer.Seeds.Core.Common;

public class ApplicationSettingsSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		ApplicationSettings settings = new ApplicationSettings
		{
			Id = (int)ApplicationSettings.Entry.Current,
			// TODO: Výchozí nastavení
		};

		Seed(For(settings).PairBy(item => item.Id).WithoutUpdate());
	}
}
