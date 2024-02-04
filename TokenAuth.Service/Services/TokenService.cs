using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TokenAuth.Repository.Models;
using TokenAuth.Service.DTOs;
using TokenAuth.Service.DTOs.Shared;

namespace TokenAuth.Service.Services
{
    public class TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        public async Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDto request)
        {
            // Claim => Auth2.0 VE OpenID Connect standartlarına göre bir kullanıcının kimliğini, yetkilerini ve diğer bilgilerini içeren bir JSON nesnesidir.

            // UserClaim=> birthDate:30.12.1990
            // RoleClaim=> scope:["create,update,delete"] // permission
            // UserRole=> Role.


            var hasUser = await userManager.FindByNameAsync(request.UserName);

            if (hasUser is null)
            {
                return ResponseDto<TokenCreateResponseDto>.Fail("Username or password is wrong");
            }

            var checkPassword = await userManager.CheckPasswordAsync(hasUser!, request.Password);

            if (checkPassword == false)
            {
                return ResponseDto<TokenCreateResponseDto>.Fail("Username or password is wrong");
            }


            var signatureKey = configuration.GetSection("TokenOptions")["SignatureKey"]!;
            var tokenExpireAsHour = configuration.GetSection("TokenOptions")["Expire"]!;
            var issuer = configuration.GetSection("TokenOptions")["Issuer"]!;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey));

            //payload => list claim Data(Key-value)
            SigningCredentials signingCredentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimList = new List<Claim>();

            var userIdAsClaim = new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString());
            var userNameAsClaim = new Claim(ClaimTypes.Name, hasUser.UserName!);
            var idAsClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());


            var userClaims = await userManager.GetClaimsAsync(hasUser);

            foreach (var claim in userClaims)
            {
                claimList.Add(new Claim(claim.Type, claim.Value));
            }


            claimList.Add(userIdAsClaim);
            claimList.Add(userNameAsClaim);
            claimList.Add(idAsClaim);
            foreach (var role in await userManager.GetRolesAsync(hasUser))
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(Convert.ToDouble(tokenExpireAsHour)),
                signingCredentials: signingCredentials,
                claims: claimList,
                issuer: issuer
            );

            var responseDto = new TokenCreateResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };


            return ResponseDto<TokenCreateResponseDto>.Success(responseDto);
        }
    }
}