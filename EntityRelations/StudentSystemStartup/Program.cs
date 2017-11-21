using P01_StudentSystem.Data;

namespace StudentSystemStartup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentSystemContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
