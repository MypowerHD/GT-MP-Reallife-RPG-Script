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
        private static Database _mysql;
        private static Configs _configs;
        private static API _api;
        private static StorePlayerData _storePlayerDataObject;
        private static Thread _storePlayerDataThread;

        public static Database Mysql => _mysql;

        public static Configs Configs => _configs;

        public static API Api => _api;

        public static StorePlayerData StorePlayerDataObject => _storePlayerDataObject;

        public static Thread StorePlayerDataThread => _storePlayerDataThread;

        public TTRPG()
        {
            _api = API;
            API.onResourceStart += TtStartUp;
        }

        public void TtStartUp()
        {
            _configs = new Configs();
            _mysql = new Database();

            if (!Configs.ConfigExists("server"))
            {
                Api.consoleOutput(LogCat.Fatal, "Configuration for server is missing in Configs directory.");
                Api.stopResource(Api.getThisResource());
            }

            API.consoleOutput("Starting TerraTex_RL_RPG Gamemode");

            _storePlayerDataObject = new StorePlayerData();
            _storePlayerDataThread = API.startThread(StorePlayerDataObject.DoWork);

            API.exported.scoreboard.addScoreboardColumn("Nachname", "Nachname", 250);
            API.exported.scoreboard.addScoreboardColumn("Vorname", "Vorname", 250);
            API.exported.scoreboard.addScoreboardColumn("ID", "ID", 40);
        }
    }
}