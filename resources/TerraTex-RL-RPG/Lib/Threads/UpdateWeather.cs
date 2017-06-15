using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTex_RL_RPG.Lib.Helper;
using System.Threading;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class UpdateWeather
    {
        private bool _interuped = false;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started DynamicWeather Thread");
            while (!_interuped)
            {
                var _loadedDie = new LoadedDie(new int[] {
                    155, //Extra Sunny
                    155, //Clear
                    155, //Clouds
                    85, //Smog
                    85, //Foggy
                    85, //Overcast
                    85, //Rain
                    85, //Thunder
                    85, //Light rain
                    85, //Smoggy light rain
                    85, //Very light Snow
                    85, //Windy light Snow
                    85, //Light snow
                    85 //Unknown (No Effect)
                });

                int _weatherID = _loadedDie.NextValue();
                string weather = "";
                switch (_weatherID)
                {
                    case 0: weather = "Extra Sunny"; break;
                    case 1: weather = "Clear"; break;
                    case 2: weather = "Clouds"; break;
                    case 3: weather = "Smog"; break;
                    case 4: weather = "Foggy"; break;
                    case 5: weather = "Overcast"; break;
                    case 6: weather = "Rain"; break;
                    case 7: weather = "Thunder"; break;
                    case 8: weather = "Light rain"; break;
                    case 9: weather = "Smoggy light rain"; break;
                    case 10: weather = "Very light Snow"; break;
                    case 11: weather = "Windy light Snow"; break;
                    case 12: weather = "Light snow"; break;
                    case 13: weather = "Unknown (No Effect)"; break;
                }

                TTRPG.Api.consoleOutput("[DynamicWeather] The Weather has changed to " + weather);
                TTRPG.Api.setWeather(_weatherID);

                Thread.Sleep(1200000);
            }

        }
    }
}
