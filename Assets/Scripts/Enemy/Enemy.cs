using Interfaces;
using Player;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public GameObject xpOrbPrefab;

        public void KillEnemy()
        {
            DropXp();
            PlayDeathEffect();
            Destroy(gameObject);
        }

        private void DropXp()
        {
            if (xpOrbPrefab != null)
            {
                Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealth player = other.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(20);
                }
            }
        }

        void PlayDeathEffect()
        {
            Debug.Log("Yokai derrotado!");
        }
    }
}