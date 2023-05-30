using Juridico.Application.Cliente.Interfaces;
using Juridico.Application.Core.Interfaces;
using Juridico.Domain.Interfaces;
using Juridico.DTL.Cliente;
using Juridico.UI.Web.Areas.Cliente.ViewModels;
using Juridico.UI.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Juridico.UI.Web.Areas.Cliente.Controllers
{

    [Area("Cliente")]
    [Route("[Area]/[controller]")]
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteApp _clienteApp;
        private readonly IEstadoCivilApp _estadoCivilApp;

        public ClienteController(IClienteApp clienteApp, IEstadoCivilApp estadoCivilApp, INotificador notificador) : base(notificador)
        {
            _clienteApp = clienteApp;
            _estadoCivilApp = estadoCivilApp;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("Cadastro")]
        [HttpGet]
        public async Task<IActionResult> Cadastro()
        {
            var lstEstadoCivil = await _estadoCivilApp.Listar();
            var oCadastroVM = new CadastroViewModel
            {
                ListaEstadoCivil = new SelectList(lstEstadoCivil, "Id", "Descricao")
            };
            return View(oCadastroVM);
        }

        [Route("Editar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var lstEstadoCivil = await _estadoCivilApp.Listar();
            //var oCliente = await _clienteApp.ObterPorId(id);

            var oCadastroVM = new CadastroViewModel
            {
                //Cliente = oCliente,
                ListaEstadoCivil = new SelectList(lstEstadoCivil, "Id", "Descricao")
            };
            return View("Cadastro", oCadastroVM);
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lstClientes = await _clienteApp.Listar();
            return CustomResponse(lstClientes);
        }

        [Route("Incluir")]
        [HttpPost]
        public async Task<IActionResult> Incluir(ClienteDTO cliente)
        {
            int id = await _clienteApp.Adicionar(cliente);
            return CustomResponse(id);
        }

        [Route("Atualizar/{id}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id || id == int.MinValue)
            {
                NotificarErro("Id Inválido");
                return CustomResponse();
            }

            await _clienteApp.Atualizar(cliente);
            return CustomResponse();
        }
        [Route("ObterCliente/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterCliente(int id)
        {
            var oCliente = await _clienteApp.ObterPorId(id);
            return CustomResponse(oCliente);
        }
    }
}
