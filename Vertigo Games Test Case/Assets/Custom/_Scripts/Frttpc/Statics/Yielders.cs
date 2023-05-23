using System.Collections.Generic;
using UnityEngine;

namespace Frttpc.Statics
{
    public static class Yielders
    {
        static Dictionary<float, WaitForSeconds> _timeInterval = new(10);

        public static WaitForSeconds Get(float seconds)
        {
            if (!_timeInterval.ContainsKey(seconds))
                _timeInterval.Add(seconds, new WaitForSeconds(seconds));

            return _timeInterval[seconds];
        }
    }
}