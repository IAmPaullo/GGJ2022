using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoHandler : MonoBehaviour
{
    [SerializeField] private Transform target, follower;
    [SerializeField] private int queueSize;
    [SerializeField] private float nearDist;
    private Queue<Memento> mementoQueue;
    public static Action CloserAction;
    public static Action EnterCloserAction;
    public static Action ExitCloserAction;
    private bool isNear;
    // Start is called before the first frame update
    void Start()
    {
        mementoQueue = new Queue<Memento>();
        follower.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        mementoQueue.Enqueue(new Memento(target.position, target.rotation));
        if(mementoQueue.Count >= queueSize)
        {
            if (!follower.gameObject.active)
                follower.gameObject.SetActive(true);
            Memento memento = mementoQueue.Dequeue();
            follower.position = memento.position;
            follower.rotation = memento.rotation;
            NearZoneHandler();
        }
        else if (follower.gameObject.active)
            follower.gameObject.SetActive(false);
    }

    public void NearZoneHandler()
    {
        if (Vector3.Distance(target.position, follower.position) < nearDist)
        {
            CloserAction?.Invoke();
            if (!isNear)
                EnterCloserAction?.Invoke();
            isNear = true;
        }
        else if (isNear)
        {
            ExitCloserAction?.Invoke();
            isNear = false;
        }
    }

    internal class Memento
    {
        internal Vector3 position;
        internal Quaternion rotation;

        public Memento(Vector3 _position, Quaternion _rotation)
        {
            position = _position;
            rotation = _rotation;
        }
    }
}
