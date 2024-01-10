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
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
