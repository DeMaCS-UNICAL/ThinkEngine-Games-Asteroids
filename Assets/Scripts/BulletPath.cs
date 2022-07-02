using UnityEngine;

public class BulletPath : MonoBehaviour
{
    public Player myPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            myPlayer.rigidbody.angularVelocity = 0;
            myPlayer.isTimeToShoot = true;
            //myPlayer.Shoot();
        }
    }

}
