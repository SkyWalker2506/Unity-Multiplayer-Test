using UnityEngine;

namespace Game.MovementSystem
{
    public interface IMovementLogic
    {
        public Transform Transform { get; }
        public float MovementSpeed { get; }
        public void Move(Vector3 moveVector);

    }
}