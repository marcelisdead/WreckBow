using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// By default if InteractorA is holding Interactable1 and you go to grab it with InteractorB, InteractorB will take it.
/// ExclusiveGrabbable gives 2 functions which can be subscribed to the XRInteractable select Events in Editor to switch the 
/// Interaction Layer of InteractorA and Interactable1 to the "exclusive" layer making it so InteractorB cant take it until InteractorA drops Interactable1.
/// Doc:"Interaction Layer Mask allows interaction with Interactors whose Interaction Layer Mask overlaps with any Layer in this Interaction Layer Mask."
/// </summary>
public class ExclusiveGrabbable : MonoBehaviour
{
    public XRBaseInteractable interactable;
    public XRBaseInteractor interactor;

    //initial layer of the interactable
    public InteractionLayerMask previousAbleLayers = ~0;//everything by default
    //initial layer of the interactactor
    public InteractionLayerMask previousActorLayers = ~0;//everything by default
    //the layer we change to
    public InteractionLayerMask exclusiveLayerMask = 1 << 10;//10 by default not sure if this needs to be titled in editor to work. Says Mixed if isnt set but i need ot test if it works



    public void Exclusive(SelectEnterEventArgs args)
    {
        previousAbleLayers = interactable.interactionLayers;
        interactable.interactionLayers = exclusiveLayerMask;

        interactor = args.interactorObject.transform.GetComponent<XRBaseInteractor>();
        previousActorLayers = interactor.interactionLayers;
        interactor.interactionLayers = exclusiveLayerMask;
    }

    public void Nonexclusive(SelectExitEventArgs args)
    {
        interactable.interactionLayers = previousAbleLayers;

        interactor = args.interactorObject.transform.GetComponent<XRBaseInteractor>();
        interactor.interactionLayers = previousActorLayers;
    }
}
