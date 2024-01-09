using ASP.NET_StudentRegisrty.Models;

namespace ASP.NET_StudentRegisrty.Data
{
    public interface IStudent
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
