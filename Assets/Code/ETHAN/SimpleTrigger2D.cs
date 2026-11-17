using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger2D : MonoBehaviour
{
    public UnityEvent collisionEnterEvent;
    public UnityEvent triggerEnterEvent;

    void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterEvent?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent?.Invoke();
    }

}
