using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Given a transform our transform will look away from it. Also can reset to an init rot.
/// This script was made to have the bow work similarly to RecRoom's Bow where the bow rotates to line up the arrow across your hands instead of wherever the bow holding hand is facing.
/// This mechanic allows for much more comfortable wrist positioning especially when trying to aim over or around something. 
/// It allows for the control of the direction of the arrow to be based on the angle between both hands instead of the angle your jiggly hand is pointing.
/// Though unrealistic and cartoony this gives much greater accuracy and control in xr.
/// </summary>
public class LookAwayFromTransform : MonoBehaviour
{
    public Transform targetTransform;
    public Transform upTransform;
    Transform _trans;
    Quaternion _resetRotation;

    void Start()
    {
        _trans = transform;
        _resetRotation = _trans.localRotation;
    }

    public void LookAway()
    {
        Vector3 targetDirection = targetTransform.position - _trans.position;
        _trans.rotation = Quaternion.LookRotation(-targetDirection, upTransform.up);
    }
    public void ResetLook()
    {
        _trans.localRotation = _resetRotation;
    }
}
