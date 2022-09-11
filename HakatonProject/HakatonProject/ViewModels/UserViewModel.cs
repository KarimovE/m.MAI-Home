using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProjectEduHome.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; } = null;
        public string Fullname { get; set; } = null;
        public string UserName { get; set;} = null;
        public string Email { get; set; } = null;
        public string Role { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
    }
}
