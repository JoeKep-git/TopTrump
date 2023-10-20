using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TopTrump.Areas.Data;

public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User); // Get the currently logged-in user
        string FirstName = user.FirstName; // Assuming the user's name is stored in the UserName property

        // Pass the userName to the view
        ViewData["FirstName"] = FirstName;

        // Your other logic here
        return View();
    }
}
