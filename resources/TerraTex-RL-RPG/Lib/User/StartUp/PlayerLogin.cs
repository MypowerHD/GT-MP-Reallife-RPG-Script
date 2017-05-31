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

                    StartLoginProcess(player);
                }
                else
                {
                    player.sendNotification("System-Error", "Das Passwort, dass du eingegeben hast, ist fehlerhaft.", false);
                    player.triggerEvent("startLogin", player.name);
                }
            }
        }

        public void StartLoginProcess(Client player)
        {
            // read all data here and store it to player before starting spawn

        }
    }
}
