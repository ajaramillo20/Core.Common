using System.Net;
using System.Net.Mail;

namespace Core.Common.Util.Helper.API
{
    public static class NotificacionesHelper
    {



        public class DatosAdjuntos
        {
            public string Ruta { get; set; }
            public string Nombre { get; set; }
        }



        public static void EnviaMensajeSimple(string subject, string body,
            List<string> cuentadestino, List<string> cuentadestinoCC, bool html)
        {
            try
            {
                var client = new SmtpClient();
                client.Host = "mail.originarsaecuador.com";
                client.Port = 587;
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("serviciocliente@originarsaecuador.com", "origimail01");

                // Dirección de origen
                var direccionOrigen = new MailAddress("notificaciones-siga@originarsaecuador.com");
                //notificaciones-siga@originrsaecuador.com

                // Mensaje
                var mensaje = new MailMessage();
                mensaje.From = direccionOrigen;
                mensaje.Subject = subject;
                mensaje.Body = body;
                mensaje.IsBodyHtml = html;

                foreach (string correoDest in cuentadestino)
                {
                    mensaje.To.Add(correoDest);
                }
                foreach (string correoDestCC in cuentadestinoCC)
                {
                    mensaje.CC.Add(correoDestCC);
                }

                client.Send(mensaje);
                // Limpieza
                mensaje = null;
                direccionOrigen = null;
                cuentadestino.Clear();
                client = null;

            }
            catch (Exception ex)
            { }


        }

        public static void EnviaMensajeSimpleconAdjunto(string asunto, string contenidoMensaje, List<string> emailsDestino, List<string> cuentaOculta,
        List<DatosAdjuntos> archivosGenerados)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "mail.originarsaecuador.com";
                client.Port = 587;
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("serviciocliente@originarsaecuador.com", "origimail01");

                // Dirección de origen
                MailAddress direccionOrigen = new MailAddress("serviciocliente@originarsaecuador.com");

                // Mensaje
                MailMessage mensaje = new MailMessage();
                mensaje.From = direccionOrigen;
                mensaje.Subject = asunto;
                mensaje.Body = contenidoMensaje;

                foreach (string correoDest in emailsDestino)
                {
                    mensaje.To.Add(correoDest);
                }

                //foreach (string correoOculto in cuentaOculta)
                //{
                //    mensaje.Bcc.Add(correoOculto);
                //}

                //if (archivosGenerados.Count() > 0)
                //{
                //    foreach (DatosAdjuntos archivo in archivosGenerados)
                //    {
                //        Attachment lv_archivo = new Attachment(archivo.Ruta);

                //        mensaje.Attachments.Add(lv_archivo);
                //    }
                //}

                client.Send(mensaje);
                mensaje.Attachments.Dispose();
                // Limpieza
                mensaje = null;
                direccionOrigen = null;
                emailsDestino.Clear();
                client = null;

            }
            catch (Exception)
            {
                //ignore
            }
        }



    }
}
