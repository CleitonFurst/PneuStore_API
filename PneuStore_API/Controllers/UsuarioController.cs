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
    public class UsuarioController : ApiBaseController
    {
        IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
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
            Usuario exists = _service.Get(id);
            return exists == null ?
                ApiNotFound("Não foi encontrado o Usuario solicitado.") :
                ApiOk(exists);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario u)
        {
            return _service.Create(u) ? ApiOk("Usuario criado com sucesso !") :
                ApiNotFound("Erro ao atualizar o usuario!");

        }
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("Usuario deletado com sucesso!") :
            ApiNotFound("Erro ao deletar o Usuario!");
        [HttpPut]
        public IActionResult Update([FromBody] Usuario u)
        {
            return _service.Update(u) ?
                ApiOk("Usuario atualizado om sucesso !") :
                ApiNotFound("Erro ao atualizar o usuario!");
        }

    }
}
