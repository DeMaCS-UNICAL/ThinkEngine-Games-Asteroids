using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    /*private void Update()
    {
        Vector2 position = transform.position;
        position.y = player.transform.position.y;
        transform.position = position;
    }*/
}
