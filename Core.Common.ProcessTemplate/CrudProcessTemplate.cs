using Core.Common.BusinessLogic.ProcessTemplate;
using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.General;
using Core.Common.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.ProcessTemplate
{
    public sealed class CrudProcessTemplate<Request, Response>
        where Request : TransaccionBase
        where Response : class, new()
    {

        private readonly IObtener<Request, Response> _logicaObtener;
        private readonly IObtenerTodos<Request, Response> _logicaObtenerTodos;
        private readonly IInsertar<Request, Response> _logicaInsertar;
        private readonly IActualizar<Request, Response> _logicaActualizar;
        private readonly IEliminar<Request, Response> _logicaEliminar;
        private readonly IProcesarTransaccion<Request, Response> _logicaProcesarTransaccion;

        public CrudProcessTemplate(IObtener<Request, Response> injectedLogic)
        {
            _logicaObtener = injectedLogic;
        }

        public CrudProcessTemplate(IObtenerTodos<Request, Response> injectedLogic)
        {
            _logicaObtenerTodos = injectedLogic;
        }

        public CrudProcessTemplate(IInsertar<Request, Response> injectedLogic)
        {
            _logicaInsertar = injectedLogic;
        }

        public CrudProcessTemplate(IActualizar<Request, Response> injectedLogic)
        {
            _logicaActualizar = injectedLogic;
        }
        public CrudProcessTemplate(IEliminar<Request, Response> injectedLogic)
        {
            _logicaEliminar = injectedLogic;
        }
        public CrudProcessTemplate(IProcesarTransaccion<Request, Response> injectedLogic)
        {
            _logicaProcesarTransaccion = injectedLogic;
        }

        
        public EstructuraBase<Response> Obtener(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaObtener;
            string fullNameSource = logica.GetType().FullName;
            var dataObtener = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");
            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataObtener);
                logica.ValidarInformacion(dataObtener);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataObtener.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataObtener.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataObtener);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> ObtenerTodos(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaObtenerTodos;

            string fullNameSource = logica.GetType().FullName;
            var dataObtenerTodos = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataObtenerTodos);
                logica.ValidarInformacion(dataObtenerTodos);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataObtenerTodos.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataObtenerTodos.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                logica.ArmarObjetoRespuesta(dataObtenerTodos);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }


        public EstructuraBase<Response> Insertar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaInsertar;

            string fullNameSource = logica.GetType().FullName;
            var dataInsertar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataInsertar);
                logica.ValidarInformacion(dataInsertar);
                logica.HomologarInformacion(dataInsertar);
                logica.InsertarInformacion(dataInsertar);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataInsertar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataInsertar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                logica.ArmarObjetoRespuesta(dataInsertar);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }
        public EstructuraBase<Response> Actualizar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaActualizar;

            string fullNameSource = logica.GetType().FullName;
            var dataActualizar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataActualizar);
                logica.ValidarInformacion(dataActualizar);
                logica.HomologarInformacion(dataActualizar);
                logica.ActualizarInformacion(dataActualizar);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataActualizar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataActualizar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                logica.ArmarObjetoRespuesta(dataActualizar);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> Eliminar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaEliminar;

            string fullNameSource = logica.GetType().FullName;
            var dataEliminar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataEliminar);
                logica.Eliminarnformacion(dataEliminar);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataEliminar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataEliminar.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                logica.ArmarObjetoRespuesta(dataEliminar);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> ProcesarTransaccion(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaProcesarTransaccion;

            string fullNameSource = logica.GetType().FullName;
            var dataProcesarTransaccion = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Entrada");

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataProcesarTransaccion);
                logica.ValidarInformacion(dataProcesarTransaccion);
                logica.AutorizarTransaccion(dataProcesarTransaccion);
                logica.EjecutarTransaccion(dataProcesarTransaccion);
                logica.ReversarTransaccion(dataProcesarTransaccion);
            }
            catch (ExcepcionServicio exServicio)
            {
                respuesta.Mensaje = exServicio.MensajeExcepcion;
                dataProcesarTransaccion.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex, fullNameSource);
                respuesta.Mensaje = excepcionServicio.MensajeExcepcion;
                dataProcesarTransaccion.Resultado = respuesta.Mensaje;
                //LogHelper.LoguearWarning(exServicio, fullnameSource);
            }
            finally
            {
                logica.ArmarObjetoRespuesta(dataProcesarTransaccion);
            }

            //LogHelper.LoguearDebug(dataObtener, fullnameSource, "TipoMensajeLogueo.Salida");
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

    }
}
