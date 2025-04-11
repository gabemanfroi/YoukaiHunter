using Interfaces;
using UnityEngine;

namespace Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public float lifetime = 8f;

        protected virtual void Start()
        {
            Destroy(gameObject, lifetime);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                OnHitEnemy(other.gameObject);
            }
        }

        protected virtual void OnHitEnemy(GameObject enemy)
        {
            
            var killable = enemy.GetComponent<IKillable>();
            
            if (killable != null)
            {
                killable.KillEnemy();
            }
            else
            {
                Destroy(enemy);
            }
            
            Destroy(gameObject); // destrói projétil
        }

    }
}