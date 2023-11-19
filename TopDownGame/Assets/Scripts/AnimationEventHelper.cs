using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHelper : MonoBehaviour
{
    public PlayerBehaviour Player;

    public void StopShooting()
    {
        Player.ShootOnce = false;
        Player.SwingOnce= false;
    }

}
