using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Action enableAction;
    public Action disableAction;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void OnEnable()
    {
        enableAction += EnableAnim;
        disableAction += DisableAnim;
    }
    private void OnDisable()
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
