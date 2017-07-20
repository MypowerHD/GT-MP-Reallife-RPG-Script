using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Helper.Weather
{
    public class Core
    {
        public int weatherID = 0;
        public string weatherName = "Not Set ATM";

        public void Boot()
        {
            getNewWeatherID();
            getWeatherName();
        }

        public void getNewWeatherID()
        {
            var _loadedDie = new LoadedDie(new int[] {
                    155, //Extra Sunny
                    155, //Clear
                    155, //Clouds
                    45, //Smog
                    45, //Foggy
                    45, //Overcast
                    45, //Rain
                    45, //Thunder
                    45, //Light rain
                    45, //Smoggy light rain
                    45, //Very light Snow
                    45, //Windy light Snow
                    45, //Light snow
                    45 //Unknown (No Effect)*/
                });

            weatherID = _loadedDie.NextValue();
        }

        public void getWeatherName()
        {
            switch (weatherID)
            {
                case 0: weatherName = "Extra Sunny"; break;
                case 1: weatherName = "Clear"; break;
                case 2: weatherName = "Clouds"; break;
                case 3: weatherName = "Smog"; break;
                case 4: weatherName = "Foggy"; break;
                case 5: weatherName = "Overcast"; break;
                case 6: weatherName = "Rain"; break;
                case 7: weatherName = "Thunder"; break;
                case 8: weatherName = "Light rain"; break;
                case 9: weatherName = "Smoggy light rain"; break;
                case 10: weatherName = "Very light Snow"; break;
                case 11: weatherName = "Windy light Snow"; break;
                case 12: weatherName = "Light snow"; break;
                case 13: weatherName = "Unknown (No Effect)"; break;
            }
        }
    }
}
