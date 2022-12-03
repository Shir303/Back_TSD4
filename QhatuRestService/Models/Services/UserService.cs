using Qhatu.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QhatuRestService.Models.Services
{
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            var settings = new Settings();
            return username.Equals(settings.username) && password.Equals(settings.password);
        }
    }
}
