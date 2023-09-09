using MsngBack.DataLayer.IContext;
using MsngBack.Models.User;

namespace MsngBack.DataLayer.InMemory;

public class InMemoryUserContext: IUserContext
{
    #region Lists

    private List<UserBase> _users = new()
    {
        new UserBase
        {
            Id = Guid.NewGuid(),
            Login = "user1",
            Name = "User1"
        },
        new UserBase
        {
            Id = Guid.NewGuid(),
            Login = "user2",
            Name = "User2"
        },
    };

    #endregion
    

    #region userMethods

    public List<UserView> GetUsersViewModel()
    {
        return _users.Select(x => (UserView)x).ToList();
    }

    public UserView? GetUserViewModelById(Guid id)
    {
        return _users.FirstOrDefault((x) => x.Id == id);
    }

    public Guid AddUser(UserView userView)
    {
        var user = userView.GetNewUserFromViewModel();
        _users.Add(user);
        return user.Id;
    }

    public UserView? UpdateUser(Guid id, UserView userView)
    {
        var userToUpdateIndex = _users
            .Select(((x, i) => new {user = x, index = i}))
            .FirstOrDefault(x => x.user.Id == id);
        if (userToUpdateIndex == null) return null;
        return _users[userToUpdateIndex.index].UpdateUser(userView);
    }

    public bool DeleteUser(Guid id)
    {
        return _users.Remove(_users.FirstOrDefault(x => x.Id == id)!);
    }

    public UserView? UpdateUserProp(Guid id, string propName, string propValue)
    {
        var userToUpdateIndex = _users
            .Select(((x, i) => new {user = x, index = i}))
            .FirstOrDefault(x => x.user.Id == id);
        if (userToUpdateIndex == null) return null;
        return _users[userToUpdateIndex.index].UpdateUserProp(propName, propValue);
    }
    
    #endregion
}