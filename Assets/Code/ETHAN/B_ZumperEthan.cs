using UnityEngine;
using UnityEngine.Events;

public class B_ZumperEthan : MonoBehaviour
{
    public UnityEvent collisionEnterEvent;
    public UnityEvent triggerEnterEvent;

    void OnCollisionEnter2D(Collision2D collision)
    {
        triggerEnterEvent?.Invoke();
    }


}
