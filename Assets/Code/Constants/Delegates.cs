using UnityEngine;
using Game;

namespace Constants
{

    public static class Delegates
    {
        
        public delegate void GameStateChange(EGameState state);
        public delegate void AxisShiftDelegate(Vector3 axisShift, float deltaTime);
        
    }

}