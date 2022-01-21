using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserDetail> WithoutPasswords(this IEnumerable<UserDetail> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static UserDetail WithoutPassword(this UserDetail user)
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}
