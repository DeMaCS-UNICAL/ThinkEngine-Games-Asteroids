using Planner;
using UnityEngine;

public class FireAction : Action
{
    public int desiredPathX { get; set; }
    public int desiredPathY { get; set; }

    public override void Do()
    {
        Player myPlayer = FindObjectOfType<Player>();
        //BulletPath myBulletPath = FindObjectOfType<BulletPath>();
        //myPlayer.turnDirection = 0f;
        float rotationZ = Mathf.Atan2(desiredPathX/1000, desiredPathY / 1000) * Mathf.Rad2Deg;
        rotationZ -= 90;
        if (myPlayer.rigidbody.rotation < rotationZ)
        {
            myPlayer.turnDirection = 1f;
        }
        else
        {
            myPlayer.turnDirection = -1f;
        }
        Debug.Log("rotate and fire");
    }

    public override bool Done()
    {
        return true;
    }

    public override State Prerequisite()
    {
        Player myPlayer = FindObjectOfType<Player>();
        if (myPlayer == null || myPlayer.turnDirection != 0f)
            return State.ABORT;

        //if (emergency && GameObject.Find("Missile(Clone)") == null)
        //    return State.ABORT;

        //        if (!emergency && System.Math.Abs(xNext-myPlayer.GetComponent<IntPair>().x) > 1000)
        //            return State.SKIP;

        return State.READY;
    }
}
