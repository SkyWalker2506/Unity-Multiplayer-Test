using UnityEngine;

namespace Game.MovementSystem
{
    public interface ILookLogic
    {
        Transform Transform { get; }
        Transform Camera { get; }
        float LookSensitivity { get; }
        Vector2 LookAngle { get; }

        void Look(Vector2 rotationDelta);
    }
}