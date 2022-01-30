using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Action enableAction;
    public Action disableAction;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    protected void OnEnable()
    {
        enableAction += EnableAnim;
        disableAction += DisableAnim;
    }
    protected void OnDisable()
    {
        enableAction -= EnableAnim;
        disableAction -= DisableAnim;
    }

    private void EnableAnim()
    {
        animator.SetBool("Active", true);
    }
    private void DisableAnim()
    {
        animator.SetBool("Active", false);
    }
}
