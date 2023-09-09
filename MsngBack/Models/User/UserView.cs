namespace MsngBack.Models.User;

public class UserView
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }

    public UserBase GetNewUserFromViewModel()      // todo: move to NewUser class
    {
        return new UserBase()
        {
            Id = Guid.NewGuid(),
            Login = this.Login,
            Name = this.Name
        };
    }
    public UserBase GetUserFromViewModel(Guid id)
    {
        return new UserBase()
        {
            Id = id,
            Login = this.Login,
            Name = this.Name
        };
    }
}