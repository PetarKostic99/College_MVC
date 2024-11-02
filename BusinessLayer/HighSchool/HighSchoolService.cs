using DataAccess;
using BusinessObjectModel;

namespace BusinessLayer
{
    public class HighSchoolService : GenericService<HighSchool>
    {
        public HighSchoolService(IGenericRepository<HighSchool> highSchoolRepository) : base(highSchoolRepository)
        {
            
        }
    }
}
