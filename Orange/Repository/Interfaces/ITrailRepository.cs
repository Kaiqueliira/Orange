using Orange.Model;

namespace Orange.Repository.Interfaces
{
    public interface ITrailRepository
    {
        Task<List<Trail>> GetAllTrails();
        Task<Trail> GetTrailById(int id);
        Task<Trail> AddTrail(Trail trail);
        Task<Trail> UpdateTrail(int id, Trail trail);
        Task<bool> DeleteTrail(int id);

    }
}
