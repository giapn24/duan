using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace vesion15.Controllers
{
    public class BaseController : Controller
    {
        public string CurrentUser
        {
            get { return HttpContext.Session.GetString("TenDangNhap"); }
            set { HttpContext.Session.SetString("TenDangNhap", value); }
        }

        public bool IsLogin
        {
            get { return !string.IsNullOrEmpty(CurrentUser); }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewBag.CurrentUser = CurrentUser;
        }
    }
}
