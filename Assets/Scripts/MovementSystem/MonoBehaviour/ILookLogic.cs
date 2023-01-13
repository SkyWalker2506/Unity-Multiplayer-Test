using UnityEngine;

namespace Game.MovementSystem
{
    public interface ILookLogic
    {
        Transform Transform { get; }
        Transform Camera { get; }
        float LookSensitivity { get; }
        void Look(Vector2 rotationDelta);
    }
}