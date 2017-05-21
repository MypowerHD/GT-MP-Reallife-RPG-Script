using GrandTheftMultiplayer.Server.API;

namespace TerraTex_RL_RPG
{
    public class TTRPG : Script
    {
        public TTRPG()
        {
            API.onResourceStart += ttStartUp;
        }

        public void ttStartUp()
        {
            API.consoleOutput("Starting TerraTex_RL_RPG Gamemode");
        }
    }
}
