using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoHandler : MonoBehaviour
{
    [SerializeField] private Transform target, follower;
    [SerializeField] private int queueSize;
    private Queue<Memento> mementoQueue;
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
        }
        else if (follower.gameObject.active)
        {
            follower.gameObject.SetActive(false);
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
