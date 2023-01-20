using Steve.Data;
using Steve.Model;
using System.Linq.Expressions;

namespace Steve.Service
{
    public class UserService : IUserService
    {
        private readonly SteveContext _steveContext;
        public UserService(SteveContext steveContext)
        {
            _steveContext = steveContext;
        }

        /// <summary>
        /// chekc here valid user or not
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public Tuple<bool, Users> ValidLogin(LoginViewModel loginViewModel)
        {
            Expression<Func<Users, bool>> filter = _ => (_.EmailId == loginViewModel.UserName || _.UserName == loginViewModel.UserName) && _.Password == loginViewModel.Password;

            Users users = _steveContext.Users.SingleOrDefault(filter);
            if (users != null)
            {
                return Tuple.Create(true, users);
            }

            return Tuple.Create(false, users);
        }
    }
}
