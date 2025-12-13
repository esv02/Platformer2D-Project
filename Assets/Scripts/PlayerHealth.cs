using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Starting health value for the Player
    public int health = 100;
    public Image healthImage;
    // Amount of damage the Player takes when hit
    public int damageAmount = 25;

    private bool isImmune = false;
    private SpriteRenderer spriteRenderer;
    private Coroutine coroutine;
    private Color originalColour;


    private void Start()
    {
        // Get the SpriteRenderer component attached to the Player
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealthBar(); //Update HealthBar at start
        originalColour = spriteRenderer.color;
    }

    // Method to reduce health when damage is taken
    public void TakeDamage()
    {
        if (isImmune)
        {
            return;
        }
        health -= damageAmount; // subtract damage amount
        UpdateHealthBar(); // Update HealthBar each frame
        StartCoroutine(BlinkRed());

        // Play hurt sound
        SoundManager.Instance.PlaySFX("HURT");

        // If health reaches zero or below, call Die()
        if (health <= 0)
        {
            Die();
        }
    }

    public void ImmunityOn(float duration)
    {
        isImmune = true;
        Invoke(nameof(ImmunityOff), duration);

        StartCoroutine("Flash");
    }

    private void ImmunityOff()
    {
        isImmune = false;
        spriteRenderer.color = Color.white;
    }

    private IEnumerator Flash()
    {
        while (isImmune)
        {
            spriteRenderer.color = new Color(originalColour.r, originalColour.g, originalColour.b, 0f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void UpdateHealthBar()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = health / 100f;
        }
    }

    // Coroutine to flash the Player red for 0.1 seconds
    private System.Collections.IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    // Reload the scene when the Player dies
    private void Die() =>
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
