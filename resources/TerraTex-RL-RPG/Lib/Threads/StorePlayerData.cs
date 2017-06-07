﻿using System.Collections.Generic;
using System.Threading;
using GrandTheftMultiplayer.Server.Elements;
using MySql.Data.MySqlClient;

namespace TerraTex_RL_RPG.Lib.User.Threads
{
    public class StorePlayerData
    {
        private bool _interuped = false;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started User Data Store Thread");

            while (!_interuped)
            {
                List<Client> players = TTRPG.Api.getAllPlayers();

                foreach (Client player in players)
                {
                    if (player.hasSyncedData("loggedin") && (bool) player.getSyncedData("loggedin"))
                    {
                        StartToStorePlayerData(player);
                    }
                }

                Thread.Sleep(900000);
            }
        }

        public void StartToStorePlayerData(Client player)
        {
            StoreTableUserData(player);
            StoreTableUserInventory(player);
        }

        private void StoreTableUserData(Client player)
        {
            MySqlCommand updateUserCommand = TTRPG.Mysql.Conn.CreateCommand();
            updateUserCommand.CommandText = "UPDATE user_data SET " +
                                            "PlayTime = @PlayTime " +
                                            "WHERE UserID = @UserID";

            updateUserCommand.Parameters.AddWithValue("@PlayTime", player.getSyncedData("PlayTime"));

            // general ID
            updateUserCommand.Parameters.AddWithValue("@UserID", player.getSyncedData("ID"));

            updateUserCommand.ExecuteNonQuery();
        }

        private void StoreTableUserInventory(Client player)
        {
            MySqlCommand updateUserCommand = TTRPG.Mysql.Conn.CreateCommand();
            updateUserCommand.CommandText = "UPDATE user_inventory SET " +
                                            "Money = @Money " +
                                            "BankAccount = @BankAccount " +
                                            "Phone = @Phone " +
                                            "WHERE UserID = @UserID";

            updateUserCommand.Parameters.AddWithValue("@Money", player.getSyncedData("Money"));
            updateUserCommand.Parameters.AddWithValue("@BankAccount", player.getSyncedData("BankAccount"));
            updateUserCommand.Parameters.AddWithValue("@Phone", player.getSyncedData("Phone"));

            // general ID
            updateUserCommand.Parameters.AddWithValue("@UserID", player.getSyncedData("ID"));

            updateUserCommand.ExecuteNonQuery();
        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}