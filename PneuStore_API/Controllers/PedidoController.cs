using Microsoft.AspNetCore.Mvc;
using PneuStore_API.Model;
using PneuStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Controllers
{
    public class PedidoController : ApiBaseController
    {
        IPedidoService _service;
        public PedidoController(IPedidoService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult Index() =>
           ApiOk(_service.All());

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Pedido exists = _service.Get(id);
            return exists == null ?
                ApiNotFound("Não foi encontrado o Pedido solicitado.") :
                ApiOk(exists);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pedido p) =>
            _service.Create(p) ?
            ApiOk("Produto criado com sucesso !") :
            ApiNotFound("Erro ao criar o produto!");
    

        [Route("{id}")]
        [HttpPut]
        public IActionResult Update([FromBody] Pedido p) =>
            _service.Update(p) ?
            ApiOk("O Carrinho foi atualizado com sucesso !") :
            ApiNotFound("Erro ao atualizar o carrinho");


        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
          _service.Delete(id) ?
              ApiOk("O produto foi deletado com sucesso!") :
              ApiNotFound("Erro ao deletar o produto!");
    }
}
