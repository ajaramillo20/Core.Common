using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.UI.Models.ModulosSistema
{
    public class ModuloSistema
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
