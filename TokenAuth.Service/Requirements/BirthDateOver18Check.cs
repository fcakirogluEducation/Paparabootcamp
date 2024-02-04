using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TokenAuth.API.Requirements
{
    public class BirthDateOver18Check : IAuthorizationRequirement
    {
    }

    public class BirthDateOver18CheckRequirementHandler : AuthorizationHandler<BirthDateOver18Check>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            BirthDateOver18Check requirement)
        {
            var claims = context.User.Claims;


            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            var birthDate = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth)!.Value);

            int age = DateTime.Today.Year - birthDate.Year;


            if (age >= 18)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}