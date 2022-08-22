using Core.Common.BusinessLogic.ProcessTemplate;
using Core.Common.Model.General;
using Core.Common.Model.Transaccion;
using Core.Common.ProcessTemplate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper
{
    public static class ControladorHelper
    {

        public static EstructuraBase<Response> Obtener<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IObtener<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Obtener(transaccionBLL);
        }

        public static EstructuraBase<Response> ObtenerTodos<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IObtenerTodos<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).ObtenerTodos(transaccionBLL);
        }

        public static EstructuraBase<Response> Insertar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IInsertar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Insertar(transaccionBLL);
        }

        public static EstructuraBase<Response> Actualizar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IActualizar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Actualizar(transaccionBLL);
        }

        public static EstructuraBase<Response> Eliminar<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IEliminar<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).Eliminar(transaccionBLL);
        }

        public static EstructuraBase<Response> ProcesarTransaccion<Transaccion, Response, Logica>(this ControllerBase controlador, Logica inyectedLogic, Transaccion transaccion)
            where Transaccion : TransaccionBase, new()
            where Response : class, new()
            where Logica : IProcesarTransaccion<Transaccion, Response>
        {
            EstructuraBase<Transaccion> transaccionBLL = new EstructuraBase<Transaccion>(transaccion);
            return new CrudProcessTemplate<Transaccion, Response>(inyectedLogic).ProcesarTransaccion(transaccionBLL);
        }

        public static W GenerarTransaccion<W>(this ControllerBase controlador)
            where W : TransaccionBase, new()
        {
            W transaccion = new W();
            return transaccion;
        }





    }
}
