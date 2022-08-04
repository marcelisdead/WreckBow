using UnityEngine;


/// <summary>
/// snaps our transform to the target trans, position but restricts position to be 0,0 x,y and between min and max on z when FireOnRail is fired.
/// Is reset to init pos when ResetPosition is fired.
/// Script was made to keep a bowsting only moving in one axis between 2 positions. Could be used to make slider.
/// </summary>
public class FollowTransformOnRail : MonoBehaviour
{

    public Transform targetTransform;
    
    public float railMin = -0.7f;
    public float railMax = 0;

    Transform _trans;
    Vector3 _resetPosition;


    void Start()
    {
        _trans = transform;
        _resetPosition = _trans.localPosition;
    }


    public void FollowOnRail()
    {
        _trans.position = targetTransform.position;
        _trans.localPosition = new Vector3(0, 0, Mathf.Clamp(_trans.localPosition.z, railMin, railMax));
    }

    public void ResetPosition()
    {
        _trans.localPosition = _resetPosition;
    }
}
