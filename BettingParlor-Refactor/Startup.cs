using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(BettingParlor_Refactor.Startup))]

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Class is neccessary for SignalR framework to work properly.
    /// </summary>
    /// <remarks>
    /// Initializes all cors which are needed by SignalR framework.
    /// Don't change class name otherwise SignalR will not recognise it and server can not be started.
    /// </remarks>
    /// <see cref="ClientServerConnectionsHub"/>
    public class Startup
    {
        /// <summary>
        /// Initializes all cors for SignalR framework to work properly.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
