using System.Xml;
using MySql.Data.MySqlClient;

namespace TerraTex_RL_RPG.Lib.Data
{
    public class Database
    {
        private MySqlConnection _conn;

        public Database()
        {
            XmlDocument databaseConfig = TTRPG.Configs.GetConfig("database");

            
        }
        
    }
}