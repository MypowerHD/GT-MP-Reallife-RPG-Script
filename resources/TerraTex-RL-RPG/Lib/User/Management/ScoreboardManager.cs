
using System;
using System.Data;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;

namespace TerraTex_RL_RPG.Lib.User.Management
{
    class ScoreboardManager : Script
    {
        [Command("plist", Group = "user", SensitiveInfo = false, GreedyArg = true)]
        public static void DrawScoreboard()
        {
             
        }
    }
}
