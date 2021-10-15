using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PneuStore_API.API;
using PneuStore_API.Model;
using PneuStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PneuStore_API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [AuthorizeRoles(RoleType.Common, RoleType.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ApiBaseController
    {
        IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Informa os produtos registrados
        /// </summary>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Todos")]
        public IActionResult Index() => ApiOk(_service.All());

        /// <summary>
        /// Busca um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [Route("{id}")]
        [HttpGet]

        public IActionResult Index(int? id)
        {
            var existe = _service.Get(id);
            return existe == null ?
                ApiNotFound("Produto não encontrado") :
                ApiOk(existe);
        }
        /// <summary>
        /// Busca um produto aleatorio dentro do banco
        /// </summary>
        /// <returns></returns>
        [Route("Random"), HttpGet]
        [Authorize]
        public IActionResult Random()
        {
            Random rnd = new();
            List<Product> lista = _service.All();
            return ApiOk(lista[rnd.Next(lista.Count)]);


        }
        /// <summary>
        /// Mostra os produtos criados por um tipo de usuário.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("StoresByRole/{role?}")]
        [HttpGet]
        public IActionResult StoreByRole(string role)
        {
            return ApiOk(_service.ProductByUserRole(role));
        }
        /// <summary>
        /// Cadastra um novo produto.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]

        public IActionResult Create([FromBody] Product item)
        {
            item.createdById = User.Claims.FirstOrDefault(c => c.Type
            == ClaimTypes.NameIdentifier).Value;


            return _service.Create(item) ?
            ApiOk("Produto criado com sucesso") :
            ApiNotFound("Produto não foi criado");

        }
        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Product item)
        {
            item.updatedById = User.Claims.FirstOrDefault(c => c.Type
            == ClaimTypes.NameIdentifier).Value;

            return _service.Update(item) ?
            ApiOk("Produto atualizado com sucesso") :
            ApiNotFound("Produto não foi atualizado");
        }
        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeRoles(RoleType.Admin)]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Produto deletado com sucesso") :
            ApiNotFound("Produto não foi deletado");
    }
}