using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NW.Game
{
    public static class EventsProvider
    {
        public static Transform player;
        public static Action<float> onJump;
        public static Action onGroundHit;
    }
}