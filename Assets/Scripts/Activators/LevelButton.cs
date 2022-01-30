using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : Activator
{
    bool active;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shadow") || 
            other.gameObject.layer == LayerMask.NameToLayer("Player") || 
            other.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            if (!active)
            {
                active = true;
                enableAction?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shadow") || 
            other.gameObject.layer == LayerMask.NameToLayer("Player") || 
            other.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            active = false;
            disableAction?.Invoke();
        }
    }
}
