using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using MySql.Data.MySqlClient;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.User.StartUp
{

    class PlayerLogin : Script
    {

        public PlayerLogin()
        { 
            API.onClientEventTrigger += OnClientEvent;
        }

        public void OnClientEvent(Client player, string eventName, params object[] arguments)
        {
            if (eventName.Equals("onClientStartLogin"))
            {
                string password = (string) arguments[0];

                MySqlCommand doesPlayerExistInDb = TTRPG.Mysql.Conn.CreateCommand();

                doesPlayerExistInDb.CommandText = "SELECT count(ID) FROM user WHERE Nickname = @nickname";
                doesPlayerExistInDb.Parameters.AddWithValue("@nickname", player.name);

                MySqlDataReader rdr = doesPlayerExistInDb.ExecuteReader();
                
                // There should only be one account. so we do not need a loop
                rdr.Read();

                string salt = rdr.GetString("Salt");
                string dbPassword = rdr.GetString("Password");

                if (Password.Hash(password, salt).Equals(dbPassword))
                {
                    // Password was correct and now Update fingerprint and last login
                    // before starting Login process

                    MySqlCommand updateUserEntryCommand = TTRPG.Mysql.Conn.CreateCommand();
                    updateUserEntryCommand.CommandText =
                        "UPDATE user SET Last_Fingerprint = @fingerprint, Last_Login=current_timestamp() WHERE Nickname=@nickname";
                    updateUserEntryCommand.Parameters.AddWithValue("fingerprint", player.getSyncedData("fingerprint"));
                    updateUserEntryCommand.Parameters.AddWithValue("nickname", player.name);

                    updateUserEntryCommand.ExecuteNonQuery();

                    EnsureAllDatabaseTableEntries(rdr.GetInt32("ID"));
                    StartLoginProcess(player, rdr);
                }
                else
                {
                    player.sendNotification("System-Error", "Das Passwort, dass du eingegeben hast, ist fehlerhaft.", false);
                    player.triggerEvent("startLogin", player.name);
                }
            }
        }

        public void EnsureAllDatabaseTableEntries(int dbUserId)
        {
            string[] tables = new string[]
            {
                "user_data",
                "user_inventory"
            };

            foreach (string table in tables)
            {
                MySqlCommand doesPlayerExistInDb = TTRPG.Mysql.Conn.CreateCommand();
                doesPlayerExistInDb.CommandText = "SELECT count(UserID) FROM " + table + " WHERE UserID = @id";
                doesPlayerExistInDb.Parameters.AddWithValue("@id", dbUserId);
                Int32 accounts = Int32.Parse(doesPlayerExistInDb.ExecuteScalar().ToString());
                if (accounts == 0)
                {
                    MySqlCommand createUserCommand = TTRPG.Mysql.Conn.CreateCommand();
                    createUserCommand.CommandText = "INSERT INTO " + table + " (UserID) VALUES (@id)";
                    createUserCommand.Parameters.AddWithValue("@id", dbUserId);
                    createUserCommand.ExecuteNonQuery();
                }
            }
        }

        public void StartLoginProcess(Client player, MySqlDataReader userData)
        {
            // read all data here and store it to player before starting spawn

        }
    }
}
