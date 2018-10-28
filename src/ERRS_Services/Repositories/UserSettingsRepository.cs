using DataAccess;
using DataAccess.Infraestructure;
using Entities;
using System;

namespace Repositories
{
    public class UserSettingsRepository : EntityBaseRepository<UserSetting>, IUserSettingsRepository
    {
        IConnectionFactory _connectionFactory;
        public UserSettingsRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
