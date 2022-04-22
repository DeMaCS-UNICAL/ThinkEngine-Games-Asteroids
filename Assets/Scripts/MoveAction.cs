using Planner;
using UnityEngine;

public class MoveAction : Action
{
    public int steeringX { get; set; }
    public int steeringY { get; set; }
    public int maxForce { get; set; }
    public int steeringDirection { get; set; }
    private Vector2 steering = Vector2.zero;
    public override void Do()
    {
        Player myPlayer = FindObjectOfType<Player>();
        steering.Set(steeringX/1000, steeringY/1000);
        steering.Normalize();
        steering *= maxForce/1000;
        steering *= steeringDirection;
        //myPlayer.rigidbody.AddForce(-steering);
        myPlayer.force = steering;
        Debug.Log("move");
    }

    public override bool Done()
    {
        return true;
    }

    public override State Prerequisite()
    {
        Player myPlayer = FindObjectOfType<Player>();
        if (myPlayer == null)
            return State.ABORT;

        //if (emergency && GameObject.Find("Missile(Clone)") == null)
        //    return State.ABORT;

//        if (!emergency && System.Math.Abs(xNext-myPlayer.GetComponent<IntPair>().x) > 1000)
//            return State.SKIP;

        return State.READY;
    }
}
