using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjectModel;
using BusinessLayer;
using AutoMapper;

namespace MvcAppHelloWorld
{
    public class UserAppService : GenericAppService<UsersViewModel, Users>
    {
        public UserAppService(IGenericService<Users> genericService, IMapper mapper) : base(genericService, mapper)
        {

        }
    }
}