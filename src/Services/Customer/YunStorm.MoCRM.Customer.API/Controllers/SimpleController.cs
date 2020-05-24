using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace YunStorm.MoCRM.Customer.Controllers
{
    [Route("[controller]")]
    public class SimpleController :
        AbpController
    {
        [HttpGet]
        public IEnumerable<string> Get() => new []{ "test1", "test2" };
    }
}
