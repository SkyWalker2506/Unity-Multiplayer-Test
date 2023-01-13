using UnityEngine;

namespace Game.MovementSystem
{
    public class TransformLook : ILookLogic
    {
        public Transform Transform { get; }
        public Transform Camera { get; }
        public float LookSensitivity { get; }

        private float _xRotation;

        public TransformLook(Transform transform, Transform camera, float lookSensitivity)
        {
            Transform = transform;
            Camera = camera;
            LookSensitivity = lookSensitivity;
            _xRotation = Transform.localRotation.eulerAngles.x;
        }

        public void Look(Vector2 rotationDelta)
        {
            UpdateXAxis(rotationDelta.y * LookSensitivity * Time.deltaTime);
            Transform.Rotate(Vector3.up * rotationDelta.x * LookSensitivity * Time.deltaTime);            
        }

        private void UpdateXAxis(float xDelta)
        {
            _xRotation = Mathf.Clamp(_xRotation - xDelta,-90,90);
            Camera.localRotation = Quaternion.Euler(_xRotation,0,0);
        }

    }
}