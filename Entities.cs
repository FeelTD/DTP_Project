using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTP_Project
{
    public class UserEntity
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleID { get; set; }

    }

    public class RoleEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
