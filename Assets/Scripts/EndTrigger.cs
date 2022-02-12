using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] LauncherMechanism launcherMechanism;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Constance.LayerNames.PROJECTILELAYERNAME))
        {
            if (launcherMechanism.ReadyState)
            {
                /*
                if (launcherMechanism.CloseLauncherWall.activeSelf)
                {
                    launcherMechanism.CloseLauncherWall.SetActive(false);
                }
                */
                other.GetComponent<Projectile>().ChangePosition(launcherMechanism.ProjectilePositionStart);
            }
        }
    }
}
