using System;
using UnityEngine;

namespace Projectiles
{
    public class ShurikenProjectile : SpinningProjectile
    {
        void OnDestroy()
        {
            Debug.Log("Shuriken foi destruída!");
        }
    }
}