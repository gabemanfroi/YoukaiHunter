using Interfaces;
using UnityEngine;

namespace Projectiles
{
    public class SpinningProjectile : Projectile, IThrowable
    {
        private Vector2 direction;
        private float speed;

        [Header("Spin Settings")]
        public float rotationSpeed = 360f; // graus por segundo

        public void Throw(Vector2 dir, float spd)
        {
            direction = dir.normalized;
            speed = spd;
        }

        void Update()
        {
            // movimento
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // rotação
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}