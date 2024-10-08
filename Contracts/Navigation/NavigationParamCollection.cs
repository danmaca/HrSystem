﻿using System.Collections.ObjectModel;

namespace DanM.Core.Contracts.Navigation;

public class NavigationParamCollection : Collection<NavigationParam>
{
	//public string this[string name]
	//{
	//	get => this.GetParam(name)?.Value;
	//	set => this.SetParam(name, value);
	//}

	private NavigationParam GetParam(string name)
	{
		return this.FirstOrDefault(obj => obj.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
	}
	private void SetParam(string name, string value)
	{
		var param = GetParam(name);
		if (param == null)
		{
			param = new NavigationParam()
			{
				Name = name,
			};
			Add(param);
		}
		param.Value = value ?? string.Empty;
	}

	public int? GetInt(string name)
	{
		string value = GetParam(name)?.Value;
		return string.IsNullOrEmpty(value) == false ? int.Parse(value) : null;
	}
	public void SetInt(string name, int? value)
	{
		SetParam(name, value?.ToString());
	}
}