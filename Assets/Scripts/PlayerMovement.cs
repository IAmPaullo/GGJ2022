using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform mesh;
    private Rigidbody rb;

    public static Action DeathAction;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        MementoHandler.CloserAction += Socorro;
        MementoHandler.EnterCloserAction += TaPerto;
        MementoHandler.ExitCloserAction += TaLonge;
    }
    private void OnDisable()
    {
        MementoHandler.CloserAction -= Socorro;
        MementoHandler.EnterCloserAction -= TaPerto;
        MementoHandler.ExitCloserAction -= TaLonge;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        Vector3 vel = rb.velocity;
        if (vel != Vector3.zero)
            mesh.forward = vel;
    }

    public void Move()
    {
        float speedX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float speedY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 vel = new Vector3(speedX, rb.velocity.y, speedY);
        rb.velocity = vel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shadow"))
        {
            DeathAction?.Invoke();
        }
    }
    private void Socorro()
    {
        print("AAAAAAAAAAAh");
    }
    private void TaPerto()
    {
        print("Ele ta aqui");
    }
    private void TaLonge()
    {
        print("Fugi!");
    }
}
