using DataAccess;
using BusinessObjectModel;

namespace BusinessLayer
{
    public class CollegeService : GenericService<College>
    {
        public CollegeService(IGenericRepository<College> studentsRepository) : base(studentsRepository)
        {

        }
    }
}
