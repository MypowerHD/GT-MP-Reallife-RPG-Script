using GrandTheftMultiplayer.Server.API;
using TerraTex_RL_RPG.Lib.Data.Database;

namespace TerraTex_RL_RPG
{
    public class TTRPG : Script
    {
        static public Database mysql = new Database();

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
