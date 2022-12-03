using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QhatuRestService.Models.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string username,string password);
    }
}
