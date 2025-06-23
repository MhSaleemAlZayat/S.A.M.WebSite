using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace S.A.M.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    [Authorize]
    public class ControlPanelBaseController : Controller
    {
        public string UserId { get { return GetClaimValue<string>("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"); } }
        public string UserName
        {
            get { return GetClaimValue<string>("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"); }
        }
        public string UserRole
        {
            get { return GetClaimValue<string>("http://schemas.microsoft.com/ws/2008/06/identity/claims/role"); }
        }

        protected T GetClaimValue<T>(string claimName)
        {
            string claimValue = string.Empty;
            if (((System.Security.Claims.ClaimsIdentity)HttpContext.User.Identity).Claims != null)
            {
                if (((System.Security.Claims.ClaimsIdentity)HttpContext.User.Identity).Claims.ToList().Count > 0)
                {
                    var claim = ((System.Security.Claims.ClaimsIdentity)HttpContext.User.Identity)
                        .Claims.FirstOrDefault(x => x.Type == claimName);
                    claimValue = claim?.Value;
                }
            }
            return !string.IsNullOrEmpty(claimValue) ? (T)Convert.ChangeType(claimValue, typeof(T)) : default(T);

        }
    }
}
