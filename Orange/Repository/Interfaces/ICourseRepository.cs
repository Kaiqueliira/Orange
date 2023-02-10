using Orange.Model;

namespace Orange.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> AllCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course Course);
        Task<Course> UpdateCourse(int id, Course course);
        Task<bool> DeleteCourse(int id);
    }
}
