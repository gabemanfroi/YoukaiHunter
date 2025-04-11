using Interfaces;
using UnityEngine;
using Projectiles; // importa o namespace dos projéteis

namespace Weapons
{
    public class OfudaWeapon : Weapon
    {

        public override void Shoot()
        {
            float spreadAngle = 30f; // ângulo total de dispersão
            float angleStep = projectilesPerShot > 1 ? spreadAngle / (projectilesPerShot - 1) : 0f;
            float startAngle = -spreadAngle / 2f;

            for (int i = 0; i < projectilesPerShot; i++)
            {
                float angle = startAngle + i * angleStep;
                Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

                GameObject proj = Instantiate(this.prefab, transform.position, Quaternion.identity);
                IThrowable projectile = proj.GetComponent<IThrowable>();

                if (projectile != null)
                {
                    projectile.Throw(direction, projectileSpeed);
                }
            }
        }
    }
}

