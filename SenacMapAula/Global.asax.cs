using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace br.senac.sp.mapaaula.web
{
    public class Global : System.Web.HttpApplication
    {
        public Guid AppId = Guid.NewGuid();
        public String TestMessage;

        public String GetAppDescription(String eventName)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("-------------------------------------------{0}", Environment.NewLine);
            builder.AppendFormat("Event: {0}{1}", eventName, Environment.NewLine);
            builder.AppendFormat("Guid: {0}{1}", AppId, Environment.NewLine);
            builder.AppendFormat("Thread Id: {0}{1}", System.Threading.Thread.CurrentThread.ManagedThreadId, Environment.NewLine);
            builder.AppendFormat("Appdomain: {0}{1}", AppDomain.CurrentDomain.FriendlyName, Environment.NewLine);
            builder.AppendFormat("TestMessage: {0}{1}", TestMessage, Environment.NewLine);
            builder.Append((System.Threading.Thread.CurrentThread.IsThreadPoolThread ? "Pool Thread" : "No Thread") + Environment.NewLine);

            return builder.ToString();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Trace.WriteLine(GetAppDescription("Application_Start"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Trace.WriteLine(GetAppDescription("Application_BeginRequest"));
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Manter isso no desenvolvimento, retirar no publish
            return;

            try {
                Exception ex = Server.GetLastError();
                if (ex is System.Threading.ThreadAbortException) return;

                Server.Transfer("/Oops.aspx");

                EventLog.WriteEntry("SenacMapWebApp", ex.Message, EventLogEntryType.Error);

            } catch {

            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}