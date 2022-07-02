using UnityEngine;

public class AngleBetweenVectors : MonoBehaviour
{
    public Player player;
    public Asteroid target;
    private LineRenderer lr;
    // Start is called before the first frame update
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Start()
    {
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, player.transform.position);
        Vector2 AB = target.transform.position - player.transform.position;
        float angleInRadians = Mathf.Atan(AB.y/AB.x);
        float rotationZ = angleInRadians * Mathf.Rad2Deg;
        rotationZ -= 90;
        //if(asteroid.transform.position.x < player.transform.position.x
                    //player.transform.rotation.z = 180 + rotationZ;
        //else
                    //player.transform.rotation.z = rotation.
        Debug.Log(rotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
