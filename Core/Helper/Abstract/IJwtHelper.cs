using Entities.Concrete;

namespace Core.Helper.Abstract
{
    public interface IJwtHelper
    {
        string CreateToken(User user);
    }
}
