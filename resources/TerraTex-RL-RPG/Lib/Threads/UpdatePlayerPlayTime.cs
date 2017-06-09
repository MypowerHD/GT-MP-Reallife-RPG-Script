using System;
using System.Collections.Generic;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class UpdatePlayerPlayTime
    {
        private bool _interuped = false;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started Update Player PlayTime Thread");

            while (!_interuped)
            {
                List<Client> players = TTRPG.Api.getAllPlayers();

                foreach (Client player in players)
                {
                    if (player.hasSyncedData("loggedin") && (bool)player.getSyncedData("loggedin"))
                    {
                        player.setSyncedData("PlayTime", player.getSyncedData("PlayTime") + 1);
                        int playTime = player.getSyncedData("PlayTime");

                        // format PlayTime for ScoreBoard
                        StringBuilder sbd = new StringBuilder();

                        int hours = playTime / 60;
                        sbd.Append(hours);
                        sbd.Append(" | ");
                        int minutes = playTime - hours * 60;
                        sbd.Append(minutes.ToString("D2"));

                        TTRPG.Api.exported.scoreboard.setPlayerScoreboardData(player, "PlayTime", sbd.ToString());
                    }
                }

                Thread.Sleep(60000);
            }
        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}
