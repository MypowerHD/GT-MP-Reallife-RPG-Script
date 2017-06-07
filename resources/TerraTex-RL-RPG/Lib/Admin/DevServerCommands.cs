using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Admin
{
    class DevServerCommands : Script
    {
        
        [Command("save", Group = "dev", SensitiveInfo = false, GreedyArg = true)]
        public void SaveCommand(Client player, string info = "")
        {
            if (DevServer.CheckDevCommandAccess(player))
            {
                Vector3 position = player.position;

                string path = API.getResourceFolder() + "/Logs/Position.log";
                
                if (!File.Exists(path))
                {
                    string createText = "" + Environment.NewLine;
                    File.WriteAllText(path, createText);
                }

                string appendText = position.X + ", " + position.Y + ", " + position.Z + " // " + info + Environment.NewLine;
                File.AppendAllText(path, appendText);
                player.sendNotification("Dev-System", "Saved Position: X: " + position.X + "; Y: " + position.Y + "; Z: " + position.Z);
            }
        }
    }
}
