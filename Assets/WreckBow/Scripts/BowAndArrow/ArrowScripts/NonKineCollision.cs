using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// on collision makes kinematic and fires event. if iskinematic does nothing
/// made for arrow on impact to get locked in world and play hit sound. could also work for dart or stickymine
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class NonKineCollision : MonoBehaviour
{
    public UnityEvent collisionEvent;
    Rigidbody _rigBod;

    void Start()
    {
        _rigBod = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigBod.isKinematic)
            return;
        
        _rigBod.isKinematic = true;
        collisionEvent?.Invoke();
        
    }
}
