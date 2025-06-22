using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace S.A.M.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    [Authorize]
    public class DashboardController : ControlPanelBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
