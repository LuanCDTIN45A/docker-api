using WebApiDocker.Models;

namespace WebApiDocker.Data
{
    public class Database
    {
        public readonly List<Student> Students;
        public Database()
        {
            Students = new List<Student>();
        }
    }
}
