using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Helper.Weather
{
    public class WeatherVarsOnDateTime
    {
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
        
        /*
            Used Var's
            Gedanke hier hinter ist dass man zb event's nach einer bestimmten anzahl an useds definiert
            zb 4 mal hintereinander ist Sunny oder Clear gerolled worden, dann kann mit hoher warscheinlichkeit eingewitter oder nur regen auftreten.
        */
        private int _sunnyused = 0;
        private int _clearused = 0;
        private int _cloudsused = 0;
        private int _smogused = 0;
        private int _foggyused = 0;
        private int _overcastused = 0;
        private int _rainused = 0;
        private int _thunderused = 0;
        private int _lightrainused = 0;
        private int _slrainused = 0;
        private int _vlsnowused = 0;
        private int _wlsnowused = 0;
        private int _lightsnowused = 0;
        private int _unknownused = 0;
        
        public void updateVars()
        {

        }
    }
}