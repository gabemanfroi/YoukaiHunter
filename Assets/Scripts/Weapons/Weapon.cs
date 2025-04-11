using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject prefab;
        public float shootInterval = 1f;
        protected float shootTimer = 0f;
        public int projectilesPerShot = 1; 
        public float projectileSpeed = 8f;


        protected virtual void Update()
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }

        public abstract void Shoot();
    }
}
