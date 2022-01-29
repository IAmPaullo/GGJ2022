using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : Activator
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shadow") || other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enableAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shadow") || other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            disableAction?.Invoke();
        }
    }
}
