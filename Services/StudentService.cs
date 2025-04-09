using WebApiDocker.Data;
using WebApiDocker.Dtos;
using WebApiDocker.Models;
using WebApiDocker.Services.Interface;

namespace WebApiDocker.Services
{
    public class StudentService : IStudentService
    {
        private readonly Database _database;
        public StudentService(Database database) => _database = database;
        public void AddStudent(StudentRequestDto studentRequestDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = studentRequestDto.Name,
                Age = studentRequestDto.Age
            };
            _database.Students.Add(student);
        }

        public void DeleteStudent(Guid id)
        {
            var student = _database.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _database.Students.Remove(student);
            }
            else
            {
                throw new Exception("Student not found");
            }
        }

        public List<Student> GetAllStudents()
        {
            return _database.Students;
        }

        public Student GetStudentById(Guid id)
        {
            var student = _database.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            return student;
        }

        public void UpdateStudent(Guid id, StudentRequestDto studentRequestDto)
        {
            var student = _database.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = studentRequestDto.Name;
                student.Age = studentRequestDto.Age;
            }
            else
            {
                throw new Exception("Student not found");
            }
        }
    }
}
