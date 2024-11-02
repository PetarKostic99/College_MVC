using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;

namespace MvcAppHelloWorld
{
    public class CollegeAppService : GenericAppService<CollegeViewModel, College>
    {
        private readonly IMapper mapper;

        public CollegeAppService(IGenericService<College> genericService, IMapper mapper) : base(genericService, mapper)
        {
        }
    }
}