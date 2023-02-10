using Microsoft.EntityFrameworkCore;
using Orange.Data;
using Orange.Model;
using Orange.Repository.Interfaces;
using System.Diagnostics;

namespace Orange.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OrangeContext _context;

        public CourseRepository(OrangeContext context)
        {
            _context = context;

        }
        public async Task<List<Course>> AllCourses()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            Course course = await _context.Course
               .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                throw new Exception($"O Curso não com o Id: {id} não foi encontrada no banco de Dados.");
            }

            return course;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> UpdateCourse(int id, Course course)
        {
            Course courseById = await GetCourseById(id);

            courseById.Title = course.Title;
            courseById.Author = course.Author;
            courseById.Link = course.Link;
            courseById.Trail = course.Trail;
            courseById.TrailId = course.TrailId;
            courseById.Type = course.Type;

            _context.Course.Update(courseById);
            await _context.SaveChangesAsync();

            return courseById;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            Course courseById = await GetCourseById(id);

            _context.Course.Remove(courseById);
            await _context.SaveChangesAsync();

            return true;
        }




    }
}
