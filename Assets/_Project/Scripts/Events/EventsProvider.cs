using System;
using UnityEngine;

namespace NW.Game
{
    public static class EventsProvider
    {
        public static Transform player;
        public static Action<float> onJump;
        public static Action<float[]> onJumps;

        //Game Actions
        public static Action onGroundHit;
        public static Action onWallHit;
        public static Action onCircleHit;
        public static Action onBounceFromGround;

        //Spawns
        public static Action<GameObject> onCircleSpawn;
        public static Action<GameObject> onWallSpawn;
    }
}
