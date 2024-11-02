using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class RoleAppService : GenericAppService<RoleViewModel, Role>
    {
        public RoleAppService(IGenericService<Role> genericService, IMapper mapper) : base(genericService, mapper)
        {

        }
    }
}