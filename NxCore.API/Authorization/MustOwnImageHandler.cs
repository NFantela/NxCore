using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NxCore.API.Authorization
{
    public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MustOwnImageHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            // also inject repository here
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustOwnImageRequirement requirement)
        {
            // access request to get id
            var imageId = _httpContextAccessor.HttpContext.GetRouteValue("id").ToString();
            if(!Guid.TryParse(imageId, out Guid imageIdAsGuid)){
                context.Fail();
                return Task.CompletedTask;
            }
            // if not failed we need sub claim
            var ownerId = context.User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            // here we inject repository and check image owner
            //if (_someRepo.CheckImageOwner(imageIdAsGuid, ownerId) 
            //{
            //    context.Fail();
            //    return Task.CompletedTask;
            //}
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
 