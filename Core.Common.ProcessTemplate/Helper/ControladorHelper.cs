using Core.Common.Model.Transaccion;
using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Common.Util.Helper.Autenticacion;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Core.Common.ProcessTemplate.Helper
{
    /// <summary>
    /// Clase encargada de hacer el llamado a los metodos de CRUD Process template.
    /// </summary>
    public static class ControladorHelper
    {

        public static EstructuraBase<Response> Obtener<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IObtener<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Obtener(transaccionBLL);
        }

        public static EstructuraBase<Response> ObtenerTodos<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IObtenerTodos<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).ObtenerTodos(transaccionBLL);
        }

        public static EstructuraBase<Response> Insertar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IInsertar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Insertar(transaccionBLL);
        }

        public static EstructuraBase<Response> Actualizar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IActualizar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Actualizar(transaccionBLL);
        }

        public static EstructuraBase<Response> Eliminar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IEliminar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Eliminar(transaccionBLL);
        }

        public static EstructuraBase<Response> ProcesarTransaccion<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IProcesarTransaccion<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).ProcesarTransaccion(transaccionBLL);
        }

        public static EstructuraBase<Response> ProcesarTransaccionSimple<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IProcesarTransaccionSimple<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            transaccion.Endpoint.LogicaInyectada = ObtenerNombreLogicaInyectada(inyectedLogic.ToString());
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).ProcesarTransaccionSimple(transaccionBLL);
        }

        public static W GenerarTransaccion<W>(this ControllerBase controlador)
            where W : TransaccionBase, new()
        {
            W transaccion = new W();
            var token = JwtHelper.DesencriptarJWT(controlador.Request);
            return transaccion;
        }

        public static W GenerarTransaccion<W, Request>(this ControllerBase controlador, Request request)
            where W : TransaccionBase, new()
            where Request : class
        {
            W transaccion = new W();            
            return transaccion;
        }


        private static string ObtenerNombreLogicaInyectada(string logica)
        {
            string[] listaNamespace = logica.Split('.');
            string resultado = listaNamespace.LastOrDefault().Replace("IN", string.Empty);
            return resultado;
        }

      
    }
}
