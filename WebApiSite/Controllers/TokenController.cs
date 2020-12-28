﻿using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiSite.Token;

namespace WebApiSite.Controllers
{
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
                return Unauthorized();

            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_key-12345678"))
                    .AddSubject("Empresa E-Commerce")
                    .AddIssuer("Teste.Securiry.Bearer")
                    .AddAudiance("Teste.Securiry.Bearer")
                    .AddClaim("UsuarioAPINumero", "1")
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.Value);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}