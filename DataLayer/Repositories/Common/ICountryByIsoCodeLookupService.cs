
using DanM.HrSystem.Model.Common;

namespace DanM.HrSystem.DataLayer.Repositories.Common;

public interface ICountryByIsoCodeLookupService
{
	Country GetCountryByIsoCode(string isoCode);
}
