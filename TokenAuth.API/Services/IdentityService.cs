using Microsoft.AspNetCore.Identity;
using TokenAuth.API.DTOs;
using TokenAuth.API.DTOs.Shared;
using TokenAuth.API.Models;

namespace TokenAuth.API.Services
{
    public class IdentityService(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        SignInManager<AppUser> signInManager)
    {
        public UserManager<AppUser> UserManager { get; set; } = userManager;
        public RoleManager<AppRole> RoleManager { get; set; } = roleManager;

        public SignInManager<AppUser> SignInManager { get; set; } = signInManager;


        public async Task<ResponseDto<Guid?>> CreateUser(UserCreateRequestDto request)
        {
            var appUser = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email
            };


            var result = await userManager.CreateAsync(appUser, request.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ResponseDto<Guid?>.Fail(errorList);
            }

            return ResponseDto<Guid?>.Success(appUser.Id);
        }
    }
}