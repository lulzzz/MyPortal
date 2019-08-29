using System.Web.Http;
using System.Web.Http.Controllers;
using MyPortal.Processes;

namespace MyPortal.Models.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        private string _permission;

        public HasPermissionAttribute(string permission)
        {
            _permission = permission;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return actionContext.ControllerContext.RequestContext.Principal.HasPermission(_permission);
        }
    }
}