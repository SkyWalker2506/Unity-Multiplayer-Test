using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MovementSystem
{
    public class MovementController
    {
        private Transform _objectTransform;

        public MovementController(Transform objectTransform)
        {
            _objectTransform = objectTransform;
        }
        
        public void Move(Vector3 moveVector)
        {
            _objectTransform.Translate(moveVector);
        }
    }
}