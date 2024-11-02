using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class ProfessorAppService : GenericAppService<ProfessorViewModel, Professor>
    {
        public ProfessorAppService(IGenericService<Professor> genericService, IMapper mapper) : base(genericService, mapper)
        {

        }
    }
}