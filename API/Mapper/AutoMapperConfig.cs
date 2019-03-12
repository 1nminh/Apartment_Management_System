using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Mapper
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            AutoMapper.Mapper.Initialize(x => { x.AddProfile<ModelToViewModel>(); });
        }
    }
}