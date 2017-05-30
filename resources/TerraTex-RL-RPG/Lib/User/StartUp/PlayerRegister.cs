using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.User.StartUp
{

    class PlayerRegister : Script
    {

        public PlayerRegister()
        { 
            API.onClientEventTrigger += OnClientEvent;
        }

        public void OnClientEvent(Client player, string eventName, params object[] arguments)
        {


        }
    }
}
