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
    }
}
