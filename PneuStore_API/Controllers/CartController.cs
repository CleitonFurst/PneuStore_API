using Microsoft.AspNetCore.Mvc;
using PneuStore_API.Model;
using PneuStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ApiBaseController
    {
        ICartService _service;
        public CartController(ICartService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return ApiOk(_service.All());
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id) =>
            _service.Get(id) == null ?
            ApiNotFound("Não foi encontrado o carrinho solicitado!") :
            ApiOk(_service.Get(id));

        [HttpPost]
        public IActionResult Create([FromBody] Cart c) =>
            _service.Create(c) ?
            ApiOk("Produto criado com sucesso !") :
            ApiNotFound("Erro ao criar o produto!");

        //[Route("{id}")]
        [HttpPatch]
        public IActionResult Update([FromBody] Cart c) =>
            _service.Update(c) ?
            ApiOk("O Carrinho foi atualizado com sucesso !") :
            ApiNotFound("Erro ao atualizar o carrinho");

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
          _service.Delete(id) ?
              ApiOk("O Carrinho foi deletado com sucesso!") :
              ApiNotFound("Erro ao deletar o carrinho!");

    }
}
