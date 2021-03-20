using System;
using System.Collections;

namespace Sohi.Web.Models
{
    public interface IUserRepository
    {
        User GetUser(int id);
        //IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User user);
        User Delete(int id);
    }
}
