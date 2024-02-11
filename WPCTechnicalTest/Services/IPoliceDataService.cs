using WPCTechnicalTest.Dto;

namespace WPCTechnicalTest.Services;

public interface IPoliceDataService
{
    Task<LastCrimeDateDto?> GetLastCrimeUpdatedDate(CancellationToken cancellationToken);
    Task<List<CrimeDto>?> GetCrimeDataByLocationAndDate(SearchCriteriaDto searchCriteria, CancellationToken cancellationToken);
}
