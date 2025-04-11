
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{

    public class WeaponHolder : MonoBehaviour
    {
        public List<Weapon> weapons = new List<Weapon>();
        public float shootCooldown = 1f;
        private float shootTimer;

        void Update()
        {
            shootTimer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f)
            {
                foreach (Weapon weapon in weapons)
                {
                    weapon.Shoot();
                }

                shootTimer = shootCooldown;
            }
        }
    }

}