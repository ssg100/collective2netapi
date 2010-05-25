using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Collective2.Core;

namespace Collective2.C2ATI
{
    public class AutoTradingInterface
    {
        public string LoginServer = "autotrade.collective2.com";
        public int LoginServerPort = 7878;

        public string Server = string.Empty;
        public int Port = 80;

        public string ClientID = "TESTCLIENT";
        public string Host = System.Environment.MachineName;
        public string Build = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string SessionID;


        public LoginResponse Login(string email, string password)
        {
            var result = new LoginResponse();
            var request = Core.CoreRequest.Create(LoginServer, LoginServerPort, "login");

            request.Params.Add("e", email);
            request.Params.Add("p", password);
            request.Params.Add("protoversion", "8.2");
            request.Params.Add("client", ClientID);
            request.Params.Add("h", Host);
            request.Params.Add("build", Build);

            result.RequestTime = DateTime.Now; 
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            this.SessionID = result.Session;
            this.Server = result.RedirectIP; 
            this.Port = result.RedirectPort;

            return result;
        }


        public LatestTradingSignalsResponse GetLatestTradingSignals()
        {
            var result = new LatestTradingSignalsResponse();
            var request = Core.CoreRequest.Create(this.Server, this.Port, "logoff");

            request.Params.Add("session", SessionID);
            request.Params.Add("h", Host);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public LogOffResponse LogOff()
        {
            var result = new LogOffResponse();
            var request = Core.CoreRequest.Create(this.Server, this.Port, "logoff");

            request.Params.Add("session", SessionID);
            request.Params.Add("h", Host);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            this.SessionID = string.Empty;
            this.Server = string.Empty;
            this.Port = 80;

            return result;
        }
    }
}
