using WebApiDocker.Dtos;
using WebApiDocker.Models;

namespace WebApiDocker.Services.Interface
{
    public interface IStudentService
    {
        Student GetStudentById(Guid id);
        List<Student> GetAllStudents();
        void AddStudent(StudentRequestDto studentRequestDto);
        void UpdateStudent(Guid id, StudentRequestDto studentRequestDto);
        void DeleteStudent(Guid id);
    }
}
