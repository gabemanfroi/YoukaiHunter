using UnityEngine;
using Weapons;
using System.Collections.Generic;

namespace Player
{
    public class PlayerUpgrades : MonoBehaviour
    {
        public List<Weapon> weapons;
        public PlayerMovement playerMovement;

        public void ApplyUpgrade(string upgrade)
        {
            switch (upgrade)
            {
                case "AttackSpeed":
                    foreach (var weapon in weapons)
                    {
                        weapon.shootInterval = Mathf.Max(weapon.shootInterval * 0.85f, 0.1f);
                    }
                    break;

                case "MoveSpeed":
                    playerMovement.moveSpeed += 1f;
                    break;

                case "ProjectileCount":
                    foreach (var weapon in weapons)
                    {
                        weapon.projectilesPerShot += 1;
                    }
                    break;
            }

            Debug.Log("Aplicado upgrade: " + upgrade);
        }
    }
}