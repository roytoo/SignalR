using System.Collections.Generic;
using System;
using System.IO;

namespace Microsoft.AspNet.SignalR.Client.Store.TestHost
{
    public class StoreWebSocketTestHub : Hub
    {
        public void Echo(string message)
        {
            File.AppendAllText("C:\\temp\\TestHost.log", string.Format("{0:o} {1}", DateTime.Now, message + Console.Out.NewLine));
            Clients.All.echo(message);
        }

        public IEnumerable<int> ForceReconnect()
        {
            yield return 1;
            // throwing here will close the websocket which should trigger reconnect
            throw new Exception();
        }
    }
}
