using Microsoft.AspNetCore.Mvc;
using MsngBack.DataLayer.IContext;
using MsngBack.Models.User;

namespace MsngBack.Controllers.User;

[ApiController]
[Route("api/[controller]")]
//[UserFilter] adds custom filter for controller
public class UserController : ControllerBase
{
    private readonly IUserContext _usersList;

    public UserController(IUserContext userHelper)
    {
        _usersList = userHelper;
    }
    
    #region Create

    [HttpPost]
    public ActionResult<Guid> CreateUser([FromBody]UserView user)
    {
        return Ok(_usersList.AddUser(user));
    }

    #endregion
    
    #region Read

    [HttpGet]
    public ActionResult<List<UserView>> GetUsers()
    {
        return Ok(_usersList.GetUsersViewModel());
    }
    [HttpPost]
    [Route("{id}")]
    public ActionResult<UserView> GetUsersById(Guid id)
    {
        var user = _usersList.GetUserViewModelById(id);
        if (user == null) return BadRequest(new { Error = "Invalid user id" });
        return Ok(user);
    }

    [HttpPost]
    [Route("{id}/{propName}")]
    public ActionResult<string> GetUserProp(Guid id, string propName)
    {
        var user = _usersList.GetUserViewModelById(id);
        if (user == null) return BadRequest("No such user");
        var userProp = user.GetType().GetProperty(propName);
        if (userProp == null) return BadRequest("Prop not found");
        var propValue = userProp.GetValue(user);
        return Ok(propValue);
    }

    #endregion
    
    #region Update
    
    [HttpPut]
    [Route("{id}")]
    public ActionResult<UserView> UpdateUser([FromRoute] Guid id, [FromBody] UserView userView)
    {
        var user = _usersList.UpdateUser(id, userView);
        if (user == null) return BadRequest("Something went wrong during updating user");
        return Ok(user);
    }

    [HttpPatch]
    [Route("{id}")]
    public ActionResult<UserView> UpdateUserProp(Guid id, [FromQuery] string propName, [FromQuery] string propValue)        // Method for update prop
    {
        var user = _usersList.UpdateUserProp(id, propName, propValue);
        if (user == null) return BadRequest("Something went wrong during updating user property");   // TODO: Dif exceptions to incorrect id, prop name and prop value
        return Ok(user);
    }

    #endregion
    
    #region Delete

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<bool> DeleteUsersById(Guid id)
    {
        var result = _usersList.DeleteUser(id);
        if(result) return Ok(result);
        return BadRequest(result);
    }

    #endregion
}