using UnityEngine;

// every method of this class without parameters and that returns a bool value can be used to trigger the reasoner.
 public class Trigger:ScriptableObject{

    bool fleePlan()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null && player.inContact > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    bool firePlan()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null && player.asteroidsToShoot > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool seekPlan()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null && player.goToTheCenter)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}