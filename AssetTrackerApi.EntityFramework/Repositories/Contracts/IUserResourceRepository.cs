namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IUserResourceRepository
{
    Task<double> GetTotalResourceValueOfUserAsync(int userId);

}