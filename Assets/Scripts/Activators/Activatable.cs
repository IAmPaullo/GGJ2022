using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    [SerializeField] protected Activator activator;
    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void OnEnable()
    {
        activator.enableAction += EnableAnim;
        activator.disableAction += DisableAnim;
    }
    protected void OnDisable()
    {
        activator.enableAction -= EnableAnim;
        activator.disableAction -= DisableAnim;
    }

    protected void EnableAnim()
    {
        animator.SetBool("Active", true);
    }
    protected void DisableAnim()
    {
        animator.SetBool("Active", false);
    }
}
