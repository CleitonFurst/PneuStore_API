
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PneuStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PneuStore_API.Controllers
{
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ApiController]
        [Route("[Controller]")]
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public class AuthController : ApiBaseController
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            IAuthService _service;

#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
            public AuthController(IAuthService service)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
            {
                _service = service;
            }

            /// <summary>
            /// Registra um novo usuário
            /// </summary>
            /// <param name="identityUser"></param>
            /// <returns></returns>
            [Route("Register"), HttpPost]
            [AllowAnonymous]
            public IActionResult Register([FromBody] IdentityUser identityUser)
            {
                IdentityResult result = _service.Create(identityUser).Result;
                identityUser.PasswordHash = null;
                return result.Succeeded ?
                    ApiOk(identityUser) :
                    ApiBadRequest(result.Errors, "Erro ao criar usuário");
            }
            /// <summary>
            /// Cria um token para o usuário.
            /// </summary>
            /// <param name="identityUser"></param>
            /// <returns></returns>
            [HttpPost]
            [Route("Token")]
            [AllowAnonymous]
            public IActionResult Token([FromBody] IdentityUser identityUser)
            {
                try
                {
                    return ApiOk(_service.GenerateToken(identityUser));
                }
                catch (Exception e)
                {
                    return ApiBadRequest(e, e.Message);
                }
            }

        }
    }
