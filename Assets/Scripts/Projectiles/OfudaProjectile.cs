using Interfaces;
using UnityEngine;

namespace Projectiles
{
    public class OfudaProjectile : Projectile, IThrowable
    {
        // === Orbit Behavior ===
        private Transform player;
        private float orbitAngle = 0f;
        private float orbitTimer = 0f;
        private bool isOrbiting = true;

        [Header("Orbit Settings")]
        public float orbitRadius = 1.5f;
        public float orbitSpeed = 180f; // degrees per second
        public float orbitDuration = 1f;

        // === Movement ===
        private float projectileSpeed;
        private Vector2 fallbackDirection;

        // === Targeting ===
        private Transform target;

        [Header("Homing Settings")]
        public float detectionRadius = 15f;

        // === Initialization ===
        public void Throw(Vector2 initialDir, float speed)
        {
            projectileSpeed = speed;
            fallbackDirection = initialDir.normalized;

            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null)
            {
                Debug.LogWarning("Player not found. Ofuda will not orbit.");
                isOrbiting = false;
            }
        }

        void Update()
        {
            if (isOrbiting && orbitTimer < 1)
            {
                orbitTimer += Time.deltaTime;
                OrbitAroundPlayer();
            }
            else
            {
                if (isOrbiting)
                {
                    // Finaliza órbita
                    isOrbiting = false;
                    fallbackDirection = (transform.position - player.position).normalized;
                }

                MoveTowardsTarget();
            }
        }

        #region Orbit

        private void OrbitAroundPlayer()
        {
            if (player == null) return;

            orbitAngle += orbitSpeed * Time.deltaTime;
            float radians = orbitAngle * Mathf.Deg2Rad;

            Vector2 offset = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * orbitRadius;
            transform.position = player.position + (Vector3)offset;
        }

        #endregion

        #region Homing & Movement

        private void MoveTowardsTarget()
        {
            if (target == null)
                AcquireTarget();

            Vector2 direction = target ?
                ((Vector2)target.position - (Vector2)transform.position).normalized :
                fallbackDirection;

            transform.Translate(direction * projectileSpeed * Time.deltaTime);
        }

        private void AcquireTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            float closestDistance = Mathf.Infinity;
            Transform closest = null;

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance && distance <= detectionRadius)
                {
                    closestDistance = distance;
                    closest = enemy.transform;
                }
            }

            if (closest != null)
                target = closest;
        }

        #endregion
    }
}
