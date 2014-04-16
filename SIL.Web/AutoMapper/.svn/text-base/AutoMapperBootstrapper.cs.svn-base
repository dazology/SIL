using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SIL.Domain;
using SIL.Web.AutoMapper;

namespace SIL.AutoMapper
{
    public class AutoMapperBootstrapper
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

    }
}