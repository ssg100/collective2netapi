using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Collective2.C2DS.Responses;

namespace Collective2.C2DS
{
    public class DataServices
    {
        public string Server = "data.collective2.com";
        public int Port = 80;
        public string ClientID = "TESTCLIENT";
        public string SessionID;

        public bool LoggingEnabled = false;


        private Core.CoreRequest CreateCoreRequest(string command)
        {
            var result = Core.CoreRequest.Create(Server, Port, "/cgi-perl/xml.mpl", command);
            result.LoggingEnabled = LoggingEnabled;
            return result;
        }


        public SessionResponse GetSession(string email, string password)
        {
            var result = new SessionResponse();
            var request = CreateCoreRequest("getsessionid");

            request.Params.Add("userlogin", email);
            request.Params.Add("pw", password);
            request.Params.Add("clientid", ClientID);

            result.RequestTime = DateTime.Now; 
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            this.SessionID = result.SessionID;

            return result;
        }


        public SystemRosterResponse GetSystemRoster()
        {
            var result = new SystemRosterResponse();
            var request = CreateCoreRequest("getsystemroster");

            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public SystemStatsResponse GetSystemStats(string systemid)
        {
            var result = new SystemStatsResponse();
            var request = CreateCoreRequest("getsystemstats");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public SystemOverviewResponse GetSystemOverview(string systemid)
        {
            var result = new SystemOverviewResponse();
            var request = CreateCoreRequest("getsystemoverview");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public EquitySeriesResponse GetEquitySeries(string systemid)
        {
            var result = new EquitySeriesResponse();
            var request = CreateCoreRequest("getequityseries");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public TradeHistoryResponse GetTradeHistory(string systemid)
        {
            var result = new TradeHistoryResponse();
            var request = CreateCoreRequest("gettradehistory");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public SignalHistoryResponse GetSignalHistory(string systemid)
        {
            var result = new SignalHistoryResponse();
            var request = CreateCoreRequest("getsignalhistory");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public OpenPositionsResponse GetOpenPositions(string systemid)
        {
            var result = new OpenPositionsResponse();
            var request = CreateCoreRequest("getopenpositions");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public PendingSignalsResponse GetPendingSignals(string systemid)
        {
            var result = new PendingSignalsResponse();
            var request = CreateCoreRequest("getpendingsignals");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public SubscriptionsResponse GetSubscriptions()
        {
            var result = new SubscriptionsResponse();
            var request = CreateCoreRequest("getsubscriptions");

            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public EstablishStatusResponse EstablishStatus(string systemid)
        {
            var result = new EstablishStatusResponse();
            var request = CreateCoreRequest("establishstatus");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public CheckInResponse CheckIn(string systemid)
        {
            var result = new CheckInResponse();
            var request = CreateCoreRequest("checkin");

            request.Params.Add("systemid", systemid);
            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }


        public LogOutResponse LogOut()
        {
            var result = new LogOutResponse();
            var request = CreateCoreRequest("logout");

            request.Params.Add("session", SessionID);

            result.RequestTime = DateTime.Now;
            var response = request.GetResponse();
            result.ResponseTime = DateTime.Now;

            result.Parse(response);

            return result;
        }
    }
}