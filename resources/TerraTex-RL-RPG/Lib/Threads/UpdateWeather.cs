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

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started DynamicWeather Thread");
            while (!_interuped)
            {          
                var _core = new Core();
                _core.Boot();
                
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
