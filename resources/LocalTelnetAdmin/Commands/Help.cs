using System.Net.Sockets;

namespace LocalTelnetAdmin.Commands
{
    public class Help
    {
        public static void SendHelp(NetworkStream stream)
        {
            LocalTelnetAdmin.SendResponse(stream, "Possible Commands: ");
            LocalTelnetAdmin.SendResponse(stream, "- stopResource [ResourceName]\t- will stop Resource with Name ResourceName");
            LocalTelnetAdmin.SendResponse(stream, "- startResource [ResourceName]\t- will start Resource with Name ResourceName");
            LocalTelnetAdmin.SendResponse(stream, "- restartResource [ResourceName]\t- will restart Resource with Name ResourceName");
            LocalTelnetAdmin.SendResponse(stream, "- listRunningResources\t- will list all running Resources");
        }
    }
}