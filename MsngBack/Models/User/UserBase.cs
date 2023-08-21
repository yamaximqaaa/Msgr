namespace MsngBack.Models.User;

public class UserBase
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    // public required string Login { get; set; }
    // private string _password;

    public UserBase UpdateUser(UserView userView)
    {
        Name = userView.Name; 
        //Login = userView.Login;
        return this;
    }

    public UserBase UpdateUserProp(string propName, string propValue)
    {
        var prop = GetType().GetProperty(propName);
        prop!.SetValue(this, propValue);
        return this;
    }

    public static implicit operator UserView?(UserBase? user)
    {
        if (user == null) return null;
        return new UserView()
        {
            Id = user.Id,
            //Login = user.Login,
            Name = user.Name
        };
    }
    
}