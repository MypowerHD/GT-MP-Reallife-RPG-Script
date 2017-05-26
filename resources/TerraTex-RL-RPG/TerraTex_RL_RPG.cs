using System;
using System.IO;
using System.Reflection;
using GrandTheftMultiplayer.Server.API;
using TerraTex_RL_RPG.Lib.Data;

namespace TerraTex_RL_RPG
{
    public class TTRPG : Script
    {
        static public Database Mysql;
        static public Configs Configs;
        static public API Api;

        public TTRPG()
        {
            TTRPG.Api = API;
            API.onResourceStart += ttStartUp;
        }

        public void ttStartUp()
        {
            TTRPG.Configs = new Configs();
            TTRPG.Mysql = new Database();


            API.consoleOutput("Starting TerraTex_RL_RPG Gamemode");
        }
    }
}
