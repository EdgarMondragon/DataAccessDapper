using System.Collections.Generic;
using System.Linq;
using UserSettings.API.Models;

namespace UserSettings.API.Repositories
{
    public class UserSettingsMemoryRepo : IUserSettings
    {
        private readonly List<UserSettingsModel> userSettingsList = new List<UserSettingsModel>();

        public UserSettingsMemoryRepo()
        {
            userSettingsList.Add(new UserSettingsModel
            {
                Id = 1,
                ColumnSize = 0,
                Controls = false,
                Theme = 0
            });
            userSettingsList.Add(new UserSettingsModel
            {
                Id = 2,
                ColumnSize = 1,
                Controls = true,
                Theme = 1
            });
            userSettingsList.Add(new UserSettingsModel
            {
                Id = 3,
                ColumnSize = 2,
                Controls = false,
                Theme = 1
            });
        }
        public UserSettingsModel Add(UserSettingsModel model)
        {
           
        }

        public IEnumerable<UserSettingsModel> GetAllUsers()
        {
            return userSettingsList;
        }

        public UserSettingsModel GetById(int id)
        {
            return userSettingsList.Single(p => p.Id == id);
        }
    }
}
