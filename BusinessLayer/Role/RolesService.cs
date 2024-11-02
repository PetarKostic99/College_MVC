using BusinessObjectModel;
using DataAccess;

namespace BusinessLayer
{
    public class RolesService : GenericService<Role>
    {
        public RolesService(IGenericRepository<Role> service) : base(service)
        {

        }
    }
}
