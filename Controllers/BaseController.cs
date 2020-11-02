using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        protected ObjectResult InternalServerError()
        {
            return new ObjectResult("Ocorreu um erro, tente novamente mais tarde ou se persistir contate o desenvolvimento do sistema.")
            {
                StatusCode = 500,
            };
        }

    }
}
