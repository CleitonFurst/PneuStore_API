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
    public class ProdutoController : ApiBaseController
    {
        IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index() =>
            ApiOk(_service.All());

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Product exists = _service.Get(id);
            return exists == null ?
                ApiNotFound("Não foi encontrado o produto solicitado.") :
                ApiOk(exists);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] Product p) =>
        //    _service.Create(p) ?
        //    ApiOk("Produto criado com sucesso !") :
        //    ApiNotFound("Erro ao criar o produto!");

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Product p) =>
            _service.Update(p) ?
            ApiOk("O produto foi atualizado com sucesso !") :
            ApiNotFound("Erro ao atualizar o carrinho");


        //[Route("{id}")]
        //[HttpPut]        
        //public IActionResult Update([FromBody] Product p)
        //{
           
        //    return _service.Update(p) ?
        //    ApiOk("Produto atualizado com sucesso") :
        //    ApiNotFound("Produto não foi atualizado");
        //}

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
          _service.Delete(id) ?
              ApiOk("O produto foi deletado com sucesso!") :
              ApiNotFound("Erro ao deletar o produto!");


        ///[Route("Product/{itemId}")]
        //    [HttpGet]
        //    public IActionResult ProductByUserRole(string role)// função criada para instanciar o método BooksByUserRole da classe BooksSQLService 
        //    {
        //        return ApiOk(_service.ProductByUserRole(role));// instancia o método de BooksSQLService passando como referencia o tipo de usúario (Admin/Common) e retorna usando um ApiOk
        //    }
    }
}
