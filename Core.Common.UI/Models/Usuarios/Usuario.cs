namespace Core.Common.UI.Models.Usuarios
{
    public class Usuario
    {
        public bool Autenticado { get; set; }
       
        public InformacionBase informacionBase { get; set; }

        public string RolSistema { get; set; }
    }
}
