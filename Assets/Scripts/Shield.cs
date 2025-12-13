using UnityEngine;

public class Shield : MonoBehaviour
{
    private float immuneTime = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            PlayerHealth playerHealth = GetComponentInParent<PlayerHealth>();

            playerHealth.ImmunityOn(immuneTime);

            gameObject.SetActive(false);
           
        }
    }
}
