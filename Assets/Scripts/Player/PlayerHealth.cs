using System.Collections;
using UnityEngine;

namespace Player
{
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invincibilityDuration = 1f;
    private bool _isInvincible = false;
    public DamageFlash damageFlash;
    public GameOverManager gameOverManager;




    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_isInvincible) return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        damageFlash.Flash();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityFrames());
        }
    }

    
    private IEnumerator InvincibilityFrames()
    {
        _isInvincible = true;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float elapsed = 0f;
        while (elapsed < invincibilityDuration)
        {
            if (sr != null)
            {
                sr.enabled = !sr.enabled; // pisca
            }
            elapsed += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        if (sr != null) sr.enabled = true;
        _isInvincible = false;
    }


    void Die()
    {
        Debug.Log("O jogador morreu!");
        Time.timeScale = 0f;
        gameOverManager.TriggerGameOver();
    }
}    
}
