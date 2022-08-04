using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class IPhysicallyFollow : MonoBehaviour
{
    public Transform followTargetTransform;

    public bool followRotation = true;
    public float rotateSpeed = 1;

    public bool followTranslation = true;
    public float translateSpeed = 1;

    Transform _transform;
    Rigidbody _rigbody;

    void Start()
    {
        _transform = transform;
        _rigbody = GetComponent<Rigidbody>();

        if(followTargetTransform == null)
        {
            CreateDummyTarget();
        }

        _rigbody.position = followTargetTransform.position;
        _rigbody.rotation = followTargetTransform.rotation;
    }

    void CreateDummyTarget()
    {
        followTargetTransform = new GameObject("Target").transform;
        followTargetTransform.transform.position = _transform.position;
        followTargetTransform.transform.rotation = _transform.rotation;
    }

    void Update()
    {
        PhysicallyFollow();
    }

    void PhysicallyFollow()
    {
        if (followTranslation)
        {
            float distanceFromTarget = Vector3.Distance(followTargetTransform.position, _transform.position);
            Vector3 directionToTarget = followTargetTransform.position - _transform.position;
            _rigbody.velocity = directionToTarget.normalized * (distanceFromTarget * translateSpeed);
        }

        if (followRotation)
        {
            Quaternion rotationalOffset = followTargetTransform.rotation * Quaternion.Inverse(_rigbody.rotation);
            rotationalOffset = ShortRotation(rotationalOffset);            
            rotationalOffset.ToAngleAxis(out float angle, out Vector3 axis);
            _rigbody.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        }
    }

    private Quaternion ShortRotation(Quaternion q)
    {
        if (q.w < 0)
        {
            // Convert the quaterion to eqivalent "short way around" quaterion
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        return q;
    }
}
