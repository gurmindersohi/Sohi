using System;
using System.Collections.Generic;
using System.Linq;

namespace Sohi.Web.Models
{
    public class MockUserRepository : IUserRepository
    {
        //private List<User> _userList;

        //public MockUserRepository()
        //{
        //    _userList = new List<User>()
        //    {

        //    };
        //}

        //public User GetUser(int id)
        //{

        //}
        //public User Add(User user) {
        //    //user.UserId - _userList.Max(else => else.Id) +1;
        //    return user;
        //}
        //public User Delete(int id)
        //{
        //    User user = _userList.FirstOrDefault(e => e.Id == id);
        //    if (user != null) {
        //        _userList.Remove(user);
        //    }
        //    return user;
        //}
        //public User Update(User user)
        //{
        //    User user = _userList.FirstOrDefault(e => e.Id == user.UserId);
        //    if (user != null)
        //    {
        //        _userList.Remove(user);
        //    }
        //    return user;
        //}
        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
