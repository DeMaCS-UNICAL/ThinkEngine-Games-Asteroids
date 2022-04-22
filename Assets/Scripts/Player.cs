using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Bullet bulletPrefab;

    public float thrustSpeed = 1f;
    public bool thrusting { get; set; }

    public float turnDirection { get; set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;
    private int velocityX = 0;
    private int velocityY = 0;
    public int inContact = 0;
    public int asteroidsToShoot = 0;
    public Vector2 force = Vector2.zero;
    public bool isTimeToShoot = false;
    public bool goToTheCenter = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Turn off collisions for a few seconds after spawning to ensure the
        // player has enough time to safely move away from asteroids
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        inContact = 0;
        asteroidsToShoot = 0;
        turnDirection = 0f;
        goToTheCenter = false;
        Invoke(nameof(TurnOnCollisions), respawnInvulnerability);
    }

    private void Update()
    {
        //thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        /*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }*/
        if (isTimeToShoot)
        {
            Shoot();
            isTimeToShoot = false;
        }
        velocityX = (int)(rigidbody.velocity.x * 1000);
        velocityY = (int)(rigidbody.velocity.y * 1000);
    }

    private void FixedUpdate()
    {
        //Debug.Log(transform.up);
        /*if (thrusting) {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }*/

        if (turnDirection != 0f) {
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
        rigidbody.AddForce(force);
        force.Set(0, 0);
        /*Debug.Log(targets.Count);
        if (targets.Count > 0)
        {
            Asteroid target = null;
            float minDistance = -100;
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] != null)
                {
                    float currentDistance = Vector2.Distance(targets[i].transform.position, transform.position);
                    if (currentDistance < minDistance || minDistance == -100)
                    {
                        minDistance = currentDistance;
                        target = targets[i];
                    }
                }
            }
            if (target != null)
            {
                Vector2 force = flee(target.transform.position);
                rigidbody.AddForce(force);
                //rigidbody.angularVelocity = force.magnitude;
                Vector3 difference = target.transform.position - transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                rotationZ -= 90;
                if (rigidbody.rotation < rotationZ)
                {
                    rigidbody.AddTorque(rotationSpeed);
                }
                else
                {
                    rigidbody.AddTorque(-rotationSpeed);
                }
            }
            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
        else
        {
            Vector2 force = seek(Vector3.zero);
            rigidbody.AddForce(force);
            Vector3 difference = Vector3.zero - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotationZ -= 90;
            if (rigidbody.rotation < rotationZ)
            {
                rigidbody.AddTorque(rotationSpeed);
            }
            else
            {
                rigidbody.AddTorque(-rotationSpeed);
            }
            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }*/
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
    }

    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
            gameObject.SetActive(false);
            inContact = 0;

            FindObjectOfType<GameManager>().PlayerDeath(this);
        }
    }

    public Vector2 flee(Vector3 positionTarget)
    {
        return -seek(positionTarget);
    }

    public Vector2 seek(Vector3 positionTarget)
    {
        Vector2 desiredVelocity = positionTarget - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= 5;
        Vector2 steering = desiredVelocity - rigidbody.velocity;
        if(steering.magnitude > 1f)
        {
            steering.Normalize();
            steering *= 1f;
        }
        return steering;
    }

}
