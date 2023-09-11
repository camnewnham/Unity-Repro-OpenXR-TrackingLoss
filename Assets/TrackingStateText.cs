using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class TrackingStateText : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro textMesh;
    private string sessionState = "";
    private string centerEyeState = "";
    private string headState = "";

    private void Awake()
    {
        InputTracking.trackingAcquired += OnTrackingStateChanged;
        InputTracking.trackingLost += OnTrackingStateChanged;
        ARSession.stateChanged += OnARSessionStateChanged;
        sessionState = "ARSession " + ARSession.state.ToString();
        UpdateText();
    }

    private void OnARSessionStateChanged(ARSessionStateChangedEventArgs args)
    {
        sessionState = "ARSession " + args.state.ToString();
        UpdateText();
    }

    private void OnTrackingStateChanged(XRNodeState state)
    {
        switch (state.nodeType)
        {
            case XRNode.Head:
                headState = "Head " + (state.tracked ? "Tracked" : "Lost");
                break;
            case XRNode.CenterEye:
                centerEyeState = "Center Eye " + (state.tracked ? "Tracked" : "Lost");
                break;
        }

        UpdateText();
    }

    // Update is called once per frame
    private void UpdateText()
    {
        textMesh.text = sessionState + "\n" + headState + "\n" + centerEyeState;
    }
}
