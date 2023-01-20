using Steve.Model;

namespace Steve.Service
{
    public interface IUserService
    {
        Tuple<bool,Users> ValidLogin(LoginViewModel loginViewModel);
    }
}
