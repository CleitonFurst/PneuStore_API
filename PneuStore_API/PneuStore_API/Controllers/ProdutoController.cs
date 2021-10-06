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
        ///[Route("Product/{itemId}")]
    //    [HttpGet]
    //    public IActionResult ProductByUserRole(string role)// função criada para instanciar o método BooksByUserRole da classe BooksSQLService 
    //    {
    //        return ApiOk(_service.ProductByUserRole(role));// instancia o método de BooksSQLService passando como referencia o tipo de usúario (Admin/Common) e retorna usando um ApiOk
    //    }
    }
}
