using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTex_RL_RPG.Lib.Helper.Weather;
using System.Threading;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class UpdateWeather
    {
        private bool _interuped = false;
        private int _startup = 0;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("[DynamicWeather] Started DynamicWeather Thread");
            while (!_interuped)
            {          
                var _core = new Core();
                if (TTRPG.Configs.ConfigExists("weather"))
                {
                    if (_startup == 0)
                    {
                        TTRPG.Api.consoleOutput("[DynamicWeather] Weatherconfig Found!");
                        _startup = 1;
                    }
                    int _useConfig = Int32.Parse(TTRPG.Configs.GetConfig("weather").GetElementsByTagName("useconfig")[0].InnerText);
                    int _useDateTime = Int32.Parse(TTRPG.Configs.GetConfig("weather").GetElementsByTagName("usedatetime")[0].InnerText);
                    _core.Boot(_useConfig, _useDateTime);
                }
                else
                {
                    _core.Boot(0, 0);
                }
                
                TTRPG.Api.consoleOutput("[DynamicWeather] The Weather has changed to " + _core.weatherName);
                TTRPG.Api.setWeather(_core.weatherID);

                Thread.Sleep(1200000);
            }

        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}
