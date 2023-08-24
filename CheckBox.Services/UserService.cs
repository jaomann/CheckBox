using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using System.Security.Cryptography;
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

        public string GenerateHashCode(string entity)
        {
            var md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(entity);
            byte[] hash = md5.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public User ValidateUser(User entity)
        {
            var real_user = _userRepository.GetAll().FirstOrDefault(x => x.Email.Equals(entity.Email));
            var hashPassword = GenerateHashCode(entity.Password);
            if (real_user != null && real_user.Password == hashPassword)
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
