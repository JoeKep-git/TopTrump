using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TopTrump.Models
{
    public class LobbyPageModel : PageModel
    {
        public string LobbyName { get; private set; }

        public void OnGet(string name)
        {
            LobbyName = name;
        }
    }
}
