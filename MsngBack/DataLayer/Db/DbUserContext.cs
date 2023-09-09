using MsngBack.DataLayer.IContext;
using MsngBack.Models.User;

namespace MsngBack.DataLayer.Db;

public class DbUserContext : IUserContext
{
    public List<UserView> GetUsersViewModel()
    {
        throw new NotImplementedException();
    }

    public UserView? GetUserViewModelById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid AddUser(UserView userView)
    {
        throw new NotImplementedException();
    }

    public UserView? UpdateUser(Guid id, UserView userView)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public UserView? UpdateUserProp(Guid id, string propName, string propValue)
    {
        throw new NotImplementedException();
    }
}