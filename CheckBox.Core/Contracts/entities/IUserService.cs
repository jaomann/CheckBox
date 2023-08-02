using CheckBox.Core.Entities;
using System;

namespace CheckBox.Core.Contracts.entities
{
    public interface IUserService : IBaseService<User>
    {
        User ValidateUser(User entity);
    }
}
