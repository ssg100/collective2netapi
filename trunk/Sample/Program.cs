using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "";
            string password = "";

            var c2ds = new Collective2.C2DS.DataServices()
            {
                LoggingEnabled = true
            };


            var getsession = c2ds.GetSession(email, password);

            if (getsession.Subscriptions.Length > 0)
            {
                var subscription = getsession.Subscriptions[0];
                var system = c2ds.GetSystemOverview(subscription.systemid);

            }

            var logout = c2ds.LogOut();
        }
    }
}
