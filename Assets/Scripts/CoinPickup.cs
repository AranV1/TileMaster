using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;

    bool collected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
