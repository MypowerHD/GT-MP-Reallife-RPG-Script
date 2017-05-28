using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.User.StartUp
{
    public class PlayerConnection : Script
    {
        public PlayerConnection()
        {
            API.onClientEventTrigger += OnClientEvent;
            API.onPlayerConnected += onPlayerConnectedEventHandler;
        }

        public void onPlayerConnectedEventHandler(Client player)
        {
            player.nametagVisible = false;
            player.invincible = true;
            player.position = new Vector3(0,0,200);
            player.transparency = 0;
            player.freeze(true);
            player.collisionless = true;
        }

        public void OnClientEvent(Client player, string eventName, params object[] arguments)
        {
            if (eventName.Equals("onClientResourceStarted"))
            {
                
            }
        }
    }
}