
using WPCTechnicalTest.Dto;

namespace WPCTechnicalTest.Services;

public interface IPoliceDataService
{
    //Task<IEnumerable<CrimeDto>> GetCrimeDataByLocationAndDate(string latitude, string logitude, string date);
    Task<IEnumerable<CrimeDto>> GetCrimeDataByLocationAndDate(SearchDto searchCriteria);
    Task<string> GetLastCrimeUpdatedDate();
}
