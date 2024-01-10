using ASP.NET_StudentRegisrty.Models;

namespace ASP.NET_StudentRegisrty.Data
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }     

        public IEnumerable<Student> GetAll()
        {
            return applicationDbContext.Students.OrderBy(s => s.LastName);
        }

        public Student GetById(int id)
        {
            return applicationDbContext.Students.FirstOrDefault(x => x.StudentId == id);
        }
    }
}
