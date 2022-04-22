using UnityEngine;

public class IntPair : MonoBehaviour
{
    public int x;
    public int y;

    private void Update()
    {
        x = (int)(transform.position.x*1000);
        y = (int)(transform.position.y*1000);
    }
}
