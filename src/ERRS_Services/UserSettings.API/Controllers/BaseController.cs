using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSettings.API.UnitOfWork;

namespace UserSettings.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}