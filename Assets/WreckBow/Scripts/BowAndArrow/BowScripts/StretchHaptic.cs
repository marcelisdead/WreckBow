using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Vibrates XRBaseController when value amount is changing. amount also effects that sound's pitches.
/// Made for bow stretching feel but could also make door or lever's creaking or for scaling feedback
/// </summary>
public class StretchHaptic : MonoBehaviour
{
    public int clicksPerDraw = 10;

    //amp = .01-1 dur .001 maybe bottom possible duration on quest 2
    public float amplitude = 0.1f, duration = 0.01f;
    public XRBaseController vibratingController1;
    public XRBaseController vibratingController2;

    [Range(0, 1)]
    public float currentAmount;

    float _previousAmount;

    // Update is called once per frame
    void Update()
    {

        if (currentAmount.Equals(_previousAmount))
            return;
        float betweenclicks = 1 / (clicksPerDraw - 1f);
        float currentClick = Mathf.Floor(currentAmount / betweenclicks);
        float previousClick = Mathf.Floor(_previousAmount / betweenclicks);
        if (!currentClick.Equals(previousClick))
        {
            vibratingController1.SendHapticImpulse(amplitude, duration * Mathf.Abs(currentClick - previousClick));
            vibratingController2.SendHapticImpulse(amplitude, duration * Mathf.Abs(currentClick - previousClick));
        }

        _previousAmount = currentAmount;
    }

    public void Pulse()
    {
        vibratingController1.SendHapticImpulse( 0.3f,  0.01f);
        vibratingController2.SendHapticImpulse( 0.3f,  0.01f);
    }

    public void SetAmount(float setAmount)
    {
        currentAmount = setAmount;
    }
}
