using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevel : Activatable
{
    private Collider collider;
    [SerializeField] private bool startOpen; 

    private void Start()
    {
        base.Awake();
        collider = GetComponent<Collider>();
        if (startOpen)
        {
            Open();
            EnableAnim();
        }
            
    }

    private void OnEnable()
    {
        if (startOpen)
        {
            activator.enableAction += Close;
            activator.disableAction += Open;
            activator.enableAction += DisableAnim;
            activator.disableAction += EnableAnim;
        }
        else
        {
            activator.enableAction += Open;
            activator.disableAction += Close;
            activator.enableAction += EnableAnim;
            activator.disableAction += DisableAnim;
        }
    }

    private void OnDisable()
    {
        if (startOpen)
        {
            activator.enableAction -= Close;
            activator.disableAction -= Open;
            activator.enableAction -= DisableAnim;
            activator.disableAction -= EnableAnim;

        }
        else
        {
            activator.enableAction -= Open;
            activator.disableAction -= Close;
            activator.enableAction -= EnableAnim;
            activator.disableAction -= DisableAnim;
        }
    }

    private void Open()
    {
        collider.enabled = false;
    }

    private void Close()
    {
        collider.enabled = true;
    }
}
