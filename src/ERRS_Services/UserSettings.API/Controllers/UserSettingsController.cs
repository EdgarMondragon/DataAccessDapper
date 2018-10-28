using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserSettings.API.Models;
using UserSettings.API.Repositories;
using UserSettings.API.UnitOfWork;
using Entities;

namespace UserSettings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingsController : BaseController
    {
        private readonly IUserSettings repo;

        public UserSettingsController(IUserSettings repo, IUnitOfWork unitOfWorkContext) : base(unitOfWorkContext)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userSettings = UnitOfWork.UserSettingsRepository.GetAll();
            if (!userSettings.Any())
                return new NoContentResult();
            
            return new ObjectResult(userSettings);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userSettings = UnitOfWork.UserSettingsRepository.GetBy(x => x.Id == id);
            return new ObjectResult(userSettings);
        }

        [HttpPost]
        public UserSettingsModel Add([FromBody]UserSettingsModel model)
        {
            var setting = Mapper.Map<UserSettingsModel, UserSetting>(model);
            var userSetting = Mapper.Map<UserSetting, UserSettingsModel>(UnitOfWork.UserSettingsRepository.Insert(setting));
            return userSetting;
        }
    }
}