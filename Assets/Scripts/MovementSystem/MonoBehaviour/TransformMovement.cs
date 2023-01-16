using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MovementSystem
{
    public class TransformMovement : IMovementLogic
    {
        public Transform Transform { get; }
        public float MovementSpeed { get; }

        public TransformMovement(Transform transform, float movementSpeed)
        {
            Transform = transform;
            MovementSpeed = movementSpeed;
        }
        
        public void Move(Vector3 moveVector)
        {
            Transform.position += moveVector * (MovementSpeed * Time.deltaTime);
        }
    }
}