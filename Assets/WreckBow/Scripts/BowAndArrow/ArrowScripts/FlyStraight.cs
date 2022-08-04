using UnityEngine;

/// <summary>
/// rotates transform so that it is pointed in the direction it is moving. Doesnt do anything if the rb iskinematic
/// made for arrows flight on bow and arrow
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class FlyStraight : MonoBehaviour
{
    Rigidbody _rigBod;
    Transform _trans;

    void Start()
    {
        _rigBod = GetComponent<Rigidbody>();
        _trans = transform;
    }

    private void FixedUpdate()
    {
        if (_rigBod.isKinematic)
            return;

            SetDirection();
    }

    void SetDirection()
    {
        // Look in the direction we are moving
        if (_rigBod.velocity.z > 0.5f)
            _trans.forward = _rigBod.velocity;
    }
}
