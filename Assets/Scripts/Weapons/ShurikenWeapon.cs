using Interfaces;
using Player;
using UnityEngine;
using Projectiles;

namespace Weapons
{
    public class ShurikenWeapon : Weapon
    {
        private PlayerMovement _playerMovement;

        
        void Start()
        {
            _playerMovement = FindFirstObjectByType<PlayerMovement>();
        }
        public override void Shoot()
        {
            float spreadAngle = 30f;
            float angleStep = projectilesPerShot > 1 ? spreadAngle / (projectilesPerShot - 1) : 0f;
            float startAngle = -spreadAngle / 2f;

            Vector2 baseDirection = _playerMovement.GetLookDirection(); // pega a direção do player

            for (int i = 0; i < projectilesPerShot; i++)
            {
                float angle = startAngle + i * angleStep;
                Vector2 direction = Quaternion.Euler(0, 0, angle) * baseDirection;
                
                Vector3 spawnPosition = transform.position + (Vector3)(direction.normalized * 0.5f);

                GameObject proj = Instantiate(this.prefab, spawnPosition, Quaternion.identity);
                IThrowable p = proj.GetComponent<IThrowable>();
                if (p != null)
                {
                    p.Throw(direction.normalized, projectileSpeed);
                }
            }
        }
    }
}