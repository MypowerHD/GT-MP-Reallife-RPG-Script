using System.Data;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Admin
{
    class DevServer
    { 
        public static bool CheckDevServerLogin(Client player, DataRow userData)
        {
            if (TTRPG.Configs.GetConfig("server").GetElementsByTagName("host")[0].InnerText.Equals("1"))
            {
                if ((int)userData["Dev"] == 0)
                {
                    player.sendNotification("System-Error", "Du hast keine Berechtigung, dich auf dem DevServer einzuloggen.", false);
                    player.triggerEvent("startLogin", player.name);
                    return true;
                }
            }
            return false;
        }
    }
}
