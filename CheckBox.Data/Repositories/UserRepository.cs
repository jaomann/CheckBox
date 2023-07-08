using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;

namespace CheckBox.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
            
        }
    }
}
