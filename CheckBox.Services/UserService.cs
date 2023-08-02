using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using CheckBox.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckBox.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(User entity)
        {
            var real_user = _userRepository.GetAll().FirstOrDefault(x => x.Email.Equals(entity.Email));
            if (real_user != null && real_user.Password == entity.Password)
                {
                return real_user;
            }
            else
            {
                return null;
            }
            
        }
    }
}
