using UnityEngine;

public class IntPair : MonoBehaviour
{
    public int x;
    public int y;
    public int rotationZ;

    private void Update()
    {
        x = (int)(transform.position.x*1000);
        y = (int)(transform.position.y*1000);
        rotationZ = (int)(transform.rotation.z * 1000);
    }
}
