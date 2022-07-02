using Planner;
using UnityEngine;

public class FireAction : Action
{
    public int targetX { get; set; }
    public int desiredPathX { get; set; }
    public int desiredPathY { get; set; }

    public override void Do()
    {
        Player myPlayer = FindObjectOfType<Player>();
        //BulletPath myBulletPath = FindObjectOfType<BulletPath>();
        //myPlayer.turnDirection = 0f;
        float y = desiredPathY / 1000;
        float x = desiredPathX / 1000;
        float tX = targetX / 1000;
        float rotationZ = Mathf.Atan(y/x) * Mathf.Rad2Deg;
        rotationZ -= 90;
        if (tX < myPlayer.transform.position.x)
        {
            rotationZ += 180;
        }
        float dir = 1f;
        if (areNotInTheSameQuadrantAndBottom(90,180, myPlayer.transform.rotation.z,rotationZ) || areNotInTheSameQuadrantAndBottom(-90, -180, myPlayer.transform.rotation.z, rotationZ))
        {
            dir *= -1;
        }
        if (myPlayer.transform.rotation.z < rotationZ)
        {
            myPlayer.turnDirection = dir;
        }
        else
        {
            myPlayer.turnDirection = -dir;
        }

        Debug.Log("rotate and fire");
    }

    private bool areNotInTheSameQuadrantAndBottom(float lowerBound,float upperBound, float playerRotationZ, float asteroidRotationZ)
    {
        if (playerRotationZ >= lowerBound && playerRotationZ <= upperBound )
        {
            if (asteroidRotationZ >= (lowerBound * -1) && asteroidRotationZ <= (upperBound * -1))
            {
                return true;
            }
        }
        return false;
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
