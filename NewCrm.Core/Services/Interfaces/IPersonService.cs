using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IPersonService
    {
        Task<string> AddPerson(Person person);

        Task<bool> IsExistUserName(string userName);

        Task<bool> IsExistNationalId(string nationalId);

        Task<bool> IsExistEmail(string email);

        Task<Person> Login(LoginViewModel loginViewModel);

        Task<IEnumerable<Person>> People();

        Task<bool> ChangePassword(string personNationalId, ChangePassword changePassword);

        Task<Person> UserProfile(string userId);
    }
}
