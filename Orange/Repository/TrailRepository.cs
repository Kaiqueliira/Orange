using Microsoft.EntityFrameworkCore;
using Orange.Data;
using Orange.Model;
using Orange.Repository.Interfaces;

namespace Orange.Repository
{
    public class TrailRepository : ITrailRepository

    {

        private readonly OrangeContext _context;

        public TrailRepository(OrangeContext context)
        {
            _context = context;
        }

        public async Task<List<Trail>> GetAllTrails()
        {
            return await _context.Trail.ToListAsync();
        }

        public async Task<Trail> GetTrailById(int id)
        {
            return await _context.Trail.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Trail> AddTrail(Trail trail)
        {
            await _context.Trail.AddAsync(trail);
            await _context.SaveChangesAsync();

            return trail;

        }
        public async Task<Trail> UpdateTrail(int id, Trail trail)
        {

            Trail trailById = await GetTrailById(id);

            if (trailById == null)
            {
                throw new Exception($"A Trilha não com o Id: {id} não foi encontrada no banco de Dados.");
            }

            trailById.Title = trail.Title;
            trailById.Description = trail.Description;
            trailById.Courses = trail.Courses;

            _context.Trail.Update(trailById);
            await _context.SaveChangesAsync();

            return trailById;
        }
        public async Task<bool> DeleteTrail(int id)
        {
            Trail trailById = await GetTrailById(id);

            if (trailById == null)
            {
                throw new Exception($"A Trilha não com o Id: {id} não foi encontrada no banco de Dados.");
            }

            _context.Trail.Remove(trailById);
            await _context.SaveChangesAsync();

            return true;
        }




    }
}
