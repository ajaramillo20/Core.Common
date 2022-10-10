using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.Transaccion;
using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.Model.Transaccion.Base;
using Core.Common.Util.Helper.Internal;
using Serilog.Core;
using Core.Common.Util.Helper.Datos;
using Core.Common.Model.General;
using Org.BouncyCastle.Crypto;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
        private readonly IProcesarTransaccionSimple<Request, Response> _logicaProcesarTransaccionSimple;

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
        public CrudProcessTemplate(IProcesarTransaccionSimple<Request, Response> injectedLogic)
        {
            _logicaProcesarTransaccionSimple = injectedLogic;
        }

        public EstructuraBase<Response> Obtener(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaObtener;
            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            var accion = "Obtener";
            var dataObtener = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();            
            //dataObtener = DesencriptarObjeto(dataObtener); 
            //Datos entrada,
            LogHelper.EscribirLog(accion,dataObtener.ToJson(), fullNameSource, dataObtener.Credenciales.Codigo??"", TipoMensajeLog.Entrada);
            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataObtener);
                logica.ValidarInformacion(dataObtener);
            }
            catch (ExcepcionServicio exServicio)
            {                
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataObtener.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataObtener.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataObtener.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,ex.Message, fullNameSource, dataObtener.Credenciales.Codigo??"",TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataObtener);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataObtener);
            }

            LogHelper.EscribirLog(accion,dataObtener.ToJson(), fullNameSource, dataObtener.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> ObtenerTodos(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaObtenerTodos;

            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            string accion = "obtenerTodos";
            var dataObtenerTodos = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion, dataObtenerTodos.ToJson(), fullNameSource, dataObtenerTodos.Credenciales.Codigo??"", TipoMensajeLog.Entrada);

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataObtenerTodos);
                logica.ValidarInformacion(dataObtenerTodos);
            }
            catch (ExcepcionServicio exServicio)
            {
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataObtenerTodos.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion, exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataObtenerTodos.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataObtenerTodos.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,ex.Message, fullNameSource, dataObtenerTodos.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataObtenerTodos);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataObtenerTodos);
            }

            LogHelper.EscribirLog(accion, dataObtenerTodos.ToJson(), fullNameSource, dataObtenerTodos.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> Insertar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaInsertar;
            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            const string accion = "Insertar";
            var dataInsertar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion,dataInsertar.ToJson(), fullNameSource, dataInsertar.Credenciales.Codigo??""??"", TipoMensajeLog.Entrada);

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
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataInsertar.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataInsertar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataInsertar.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion, ex.Message, fullNameSource, dataInsertar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataInsertar);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataInsertar);
            }

            LogHelper.EscribirLog(accion,dataInsertar.ToJson(), fullNameSource, dataInsertar.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }
        public EstructuraBase<Response> Actualizar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaActualizar;

            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            string accion = "Actualizar";
            var dataActualizar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion,dataActualizar.ToJson(), fullNameSource, dataActualizar.Credenciales.Codigo??"", TipoMensajeLog.Entrada);

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
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataActualizar.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataActualizar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataActualizar.Respuesta = respuesta.Mensaje; ;
                LogHelper.EscribirLog(accion,ex.Message, fullNameSource, dataActualizar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataActualizar);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataActualizar);
            }

            LogHelper.EscribirLog(accion, dataActualizar.ToJson(), fullNameSource, dataActualizar.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> Eliminar(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaEliminar;

            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            const string accion = "Eliminar";
            var dataEliminar = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion,dataEliminar.ToJson(), fullNameSource, dataEliminar.Credenciales.Codigo??"", TipoMensajeLog.Entrada);

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataEliminar);
                logica.ValidarInformacion(dataEliminar);
                logica.Eliminarnformacion(dataEliminar);
            }
            catch (ExcepcionServicio exServicio)
            {
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataEliminar.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion, exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataEliminar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataEliminar.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,ex.Message, fullNameSource, dataEliminar.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataEliminar);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataEliminar);
            }

            LogHelper.EscribirLog(accion,dataEliminar.ToJson(), fullNameSource, dataEliminar.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> ProcesarTransaccion(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaProcesarTransaccion;

            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            const string accion = "ProcesarTransaccion";
            var dataProcesarTransaccion = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion,dataProcesarTransaccion.ToJson(), fullNameSource, dataProcesarTransaccion.Credenciales.Codigo??"", TipoMensajeLog.Entrada);

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
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataProcesarTransaccion.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataProcesarTransaccion.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataProcesarTransaccion.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion,ex.Message, fullNameSource, dataProcesarTransaccion.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataProcesarTransaccion);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataProcesarTransaccion);
            }
            LogHelper.EscribirLog(accion, dataProcesarTransaccion.ToJson(), fullNameSource, dataProcesarTransaccion.Credenciales.Codigo??"", TipoMensajeLog.Salida);

            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

        public EstructuraBase<Response> ProcesarTransaccionSimple(EstructuraBase<Request> objetoTransaccional)
        {
            var logica = _logicaProcesarTransaccionSimple;
            const string accion = "ProcesarTransaccionSimple";
            string fullNameSource = logica.GetType().FullName ?? "NameSourceNotDefinedError";
            var dataProcesarTransaccionSimple = objetoTransaccional.Data;
            var respuesta = new EstructuraBase<Response>();

            //dataObtener = DesencriptarObjeto(dataObtener);
            LogHelper.EscribirLog(accion, dataProcesarTransaccionSimple.ToJson(), fullNameSource, dataProcesarTransaccionSimple.Credenciales.Codigo??"", TipoMensajeLog.Entrada);

            try
            {
                //Seguridad.ValidarSegundoFactor(dataObtener);
                logica.AgregarInformacion(dataProcesarTransaccionSimple);
                logica.ValidarInformacion(dataProcesarTransaccionSimple);
                logica.EjecutarTransaccion(dataProcesarTransaccionSimple);
            }
            catch (ExcepcionServicio exServicio)
            {
                exServicio.Mensaje = ErrorHelper.ObtenerMensajeRespuesta(exServicio.CodigoInternoError, exServicio.MensajePersonalizado);
                respuesta.Mensaje = exServicio.Mensaje;
                dataProcesarTransaccionSimple.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion, exServicio.Mensaje.MensajeRespuesta, fullNameSource, dataProcesarTransaccionSimple.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            catch (Exception ex)
            {
                ExcepcionServicio excepcionServicio = new ExcepcionServicio(ex);
                respuesta.Mensaje = excepcionServicio.Mensaje;
                dataProcesarTransaccionSimple.Respuesta = respuesta.Mensaje;
                LogHelper.EscribirLog(accion, ex.Message, fullNameSource, dataProcesarTransaccionSimple.Credenciales.Codigo??"", TipoMensajeLog.Error);
            }
            finally
            {
                respuesta.Data = logica.ArmarObjetoRespuesta(dataProcesarTransaccionSimple);
                respuesta.Meta = logica.ArmarMetaRespuesta(dataProcesarTransaccionSimple);
            }

            LogHelper.EscribirLog(accion, dataProcesarTransaccionSimple.ToJson(), fullNameSource, dataProcesarTransaccionSimple.Credenciales.Codigo??"", TipoMensajeLog.Salida);
            //dataObtener = Encriptar(dataObtener);
            //ArmarRespuesta(logicaObtener, dataObtener, respuesta);
            return respuesta;

        }

    }
}
