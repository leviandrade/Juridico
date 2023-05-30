using Juridico.DTL.Cliente;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Juridico.UI.Web.Areas.Cliente.ViewModels
{
    public class CadastroViewModel
    {
        public ClienteDTO Cliente { get; set; }
        public SelectList ListaEstadoCivil { get; set; }
    }
}
