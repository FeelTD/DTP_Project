using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DTP_Project
{   
    public class UserEntityViewModel : BindableBase
    {
        public UserEntityViewModel(UserEntity model, IEnumerable<RoleEntity> posts)
        {
            Model = model;
            var roleEntityViewModels = new List<RoleEntityViewModel>();
            foreach (var post in posts)
            {
                roleEntityViewModels.Add(new RoleEntityViewModel(post));
            }
            RoleEntityViewModels = roleEntityViewModels;
        }

        public UserEntity Model { get; set; }
        public IEnumerable<RoleEntityViewModel> RoleEntityViewModels { get; private set; }
    }

    public class RoleEntityViewModel : BindableBase
    {
        public RoleEntityViewModel(RoleEntity model)
        {
            Model = model;
        }

        public RoleEntity Model { get; set; }
    }
}
