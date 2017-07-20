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

        private int _sunny;
        private int _clear;
        private int _clouds;
        private int _smog;
        private int _foggy;
        private int _overcast;
        private int _rain;
        private int _thunder;
        private int _lightrain;
        private int _slrain;
        private int _vlsnow;
        private int _wlsnow;
        private int _lightsnow;
        private int _unknown;

        public void Boot(int useconfig, int usedatetime)
        {

            if (useconfig == 0)
            {
                if(usedatetime == 1)
                {
                    generateWeathernBasedonDateTime();
                }
                else
                {
                    generateWeatherBasedonConfigVars();
                }
            }
            else
            {
                if (usedatetime == 1)
                {
                    generateWeathernBasedonDateTime();
                }
                else
                {
                    _sunny = 155; //Extra Sunny
                    _clear = 155; //Clear
                    _clouds = 155; //Clouds
                    _smog = 45; //Smog
                    _foggy = 45; //Foggy
                    _overcast = 45; //Overcast
                    _rain = 45; //Rain
                    _thunder = 45; //Thunder
                    _lightrain = 45; //Light rain
                    _slrain = 45; //Smoggy light rain
                    _vlsnow = 45; //Very light Snow
                    _wlsnow = 45; //Windy light Snow
                    _lightsnow = 45; //Light snow
                    _unknown = 0; //Unknown (No Effect)*/
                }
            }

            getNewWeatherID();
            getWeatherName();
        }

        private void getNewWeatherID()
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

        private void getWeatherName()
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

        private void generateWeathernBasedonDateTime()
        {

        }

        private void generateWeatherBasedonConfigVars()
        {

        }
    }
}
