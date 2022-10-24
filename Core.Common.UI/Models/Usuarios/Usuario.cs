namespace Core.Common.UI.Models.Usuarios
{
    public class Usuario
    {
        public bool Autenticado { get; set; }
        public string CodigoEmpresa { get; set; }
        public string UsuarioRed { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Imagen { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }

        public string RolSistema { get; set; }
    }
}
