using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField]
    UnityEvent _trackingFound;
    [SerializeField]
    UnityEvent _trackingLost;

    public UnityEvent trackingFound { get => _trackingFound; set => _trackingFound = value; }
    public UnityEvent trackingLost { get => _trackingLost; set => _trackingLost = value; }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        trackingFound.Invoke();
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        trackingLost.Invoke();
    }
}
