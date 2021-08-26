using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter))
        {

        }
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(SessionHelper.User is null || !SessionHelper.User.IsAdmin)
            {
                context.Result = new RedirectToActionResult("Index", "FakeAuth", null);
            }
        }
    }
}
