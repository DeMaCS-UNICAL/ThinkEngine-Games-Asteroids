using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("FieldOfView") && collision.gameObject.CompareTag("Boundary"))
        {
            player.goToTheCenter = true;
        }
        if (gameObject.CompareTag("FieldOfView"))
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                player.inContact++;
            }
        }
        else if (gameObject.CompareTag("ShootView"))
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                player.asteroidsToShoot++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("FieldOfView") && collision.gameObject.CompareTag("Boundary"))
        {
            player.goToTheCenter = false;
        }
        if (gameObject.CompareTag("FieldOfView"))
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                player.inContact--;
            }
        }
        else if (gameObject.CompareTag("ShootView"))
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                player.asteroidsToShoot--;
            }
        }
    }
}
