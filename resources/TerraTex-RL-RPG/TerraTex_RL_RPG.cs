using System.Runtime.InteropServices;
using System.Threading;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using TerraTex_RL_RPG.Lib.Data;
using TerraTex_RL_RPG.Lib.User.Threads;

namespace TerraTex_RL_RPG
{
    public class TTRPG : Script
    {
        static public Database Mysql;
        static public Configs Configs;
        static public API Api;
        static public StorePlayerData StorePlayerDataObject;
        static private Thread _storePlayerDataThread;

        public TTRPG()
        {
            TTRPG.Api = API;
            API.onResourceStart += TtStartUp;
        }

        public void TtStartUp()
        {
            TTRPG.Configs = new Configs();
            TTRPG.Mysql = new Database();

            if (!TTRPG.Configs.ConfigExists("server"))
            {
                TTRPG.Api.consoleOutput(LogCat.Fatal, "Configuration for server is missing in Configs directory.");
                TTRPG.Api.stopResource(TTRPG.Api.getThisResource());
            }

            API.consoleOutput("Starting TerraTex_RL_RPG Gamemode");

            StorePlayerDataObject = new StorePlayerData();
            _storePlayerDataThread = API.startThread(StorePlayerDataObject.DoWork);

            API.exported.scoreboard.addScoreboardColumn("ID", "ID", 10);
            API.exported.scoreboard.addScoreboardColumn("Vorname", "Vorname", 35);
            API.exported.scoreboard.addScoreboardColumn("Nachname", "Nachname", 35);
        }
        
    }
}
