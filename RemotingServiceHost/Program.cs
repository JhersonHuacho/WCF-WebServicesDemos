using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelloRemotingService.HelloRemotingService service = 
                new HelloRemotingService.HelloRemotingService();
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(HelloRemotingService.HelloRemotingService),
                "GetMessage",
                WellKnownObjectMode.Singleton);
            Console.WriteLine("Remoting service started @ " + DateTime.Now);
            Console.ReadLine();
        }
    }
}
