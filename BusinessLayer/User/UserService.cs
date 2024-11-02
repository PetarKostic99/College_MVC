using BusinessObjectModel;
using DataAccess;

namespace BusinessLayer
{
    public class UserService : GenericService<Users>
    {
        public UserService(IGenericRepository<Users> repository) : base(repository)
        {

        }
    }
}
