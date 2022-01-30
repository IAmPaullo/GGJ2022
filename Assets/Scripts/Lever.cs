using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Activator
{
    [SerializeField] float timer;
    private bool active;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shadow") ||
            other.gameObject.layer == LayerMask.NameToLayer("Player") ||
            other.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            if (!active)
            {
                SoundManager.Play("Alavanca");
                enableAction?.Invoke();
                if (timer > 0)
                    StartCoroutine(StartTimer());
            }
        }
    }

    private IEnumerator StartTimer()
    {
        active = true;
        yield return new WaitForSeconds(timer);
        active = false;
        disableAction?.Invoke();
    }
}
