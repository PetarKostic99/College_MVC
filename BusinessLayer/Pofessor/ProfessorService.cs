using BusinessObjectModel;
using DataAccess;

namespace BusinessLayer
{
    public class ProfessorService : GenericService<Professor>
    {
        public ProfessorService(IGenericRepository<Professor> repository) : base(repository)
        {

        }
    }
}
