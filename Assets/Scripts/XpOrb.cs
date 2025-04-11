using Player;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpValue = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerXp playerXp = other.GetComponent<PlayerXp>();
            if (playerXp != null)
            {
                playerXp.GainXp(xpValue);
            }
            Destroy(gameObject);
        }
    }
}