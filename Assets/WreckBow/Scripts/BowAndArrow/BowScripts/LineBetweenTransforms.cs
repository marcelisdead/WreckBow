using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Given an array of transforms, draw a line With unitys line renderer between those
/// </summary>
[RequireComponent(typeof(LineRenderer))]

//uncomment next line to have editor draw the line between the transforms outside playmode.
//You can then recomment it and the line will stay drawn.
//otherwise Editor is always redrawing it for no reason.
[ExecuteInEditMode]

public class LineBetweenTransforms : MonoBehaviour
{
    public Transform[] transforms;
    public float lineWidth = .01f;
    LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = transforms.Length;
        _lineRenderer.widthMultiplier = lineWidth;
    }

    void Update()
    {
        for(int i =0; i < transforms.Length; i++)
        {
            _lineRenderer.SetPosition(i, transforms[i].position);
        }
    }
}
