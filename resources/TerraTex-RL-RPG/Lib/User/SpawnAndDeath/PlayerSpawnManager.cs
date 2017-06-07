using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.User.SpawnAndDeath
{
    public class PlayerSpawnManager
    {
        public static void Spawn(Client player)
        {
            player.nametagVisible = true;
            player.position = new Vector3(259.8162, -1204.156, 29.28907);
            player.transparency = 255;
            player.freeze(false);
            player.collisionless = false;

            //void _DISABLE_AUTOMATIC_RESPAWN(BOOL disableRespawn) // 2C2B3493FBF51C71 296574AE
        }
    }
}