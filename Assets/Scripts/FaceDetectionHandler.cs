using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class FaceDetectionHandler : MonoBehaviour
{
    public GameObject scanButton;
    public GameObject backButton;

    private ARFaceManager faceManager;
    private bool hasScanned = false;

    void Start()
    {
        scanButton?.SetActive(false);
        faceManager = FindObjectOfType<ARFaceManager>();
        if (faceManager == null)
        {
            Debug.LogError("ARFaceManager missing! Ensure it's on AR Session Origin.");
        }
    }

    void Update()
    {
        if (faceManager == null) return;

        // Count actively tracked faces
        int faceCount = 0;
        foreach (var face in faceManager.trackables)
        {
            if (face.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                faceCount++;
        }

        bool hasFace = faceCount > 0;

        if (hasFace && !hasScanned)
            scanButton?.SetActive(true);
        else if (!hasFace)
            scanButton?.SetActive(false);
    }

    public void OnScanButtonPressed()
    {
        if (hasScanned) return;
        hasScanned = true;

        string condition = Random.value switch
        {
            < 0.6f => "Healthy",
            < 0.9f => "Acne",
            _ => "Rash"
        };

        PlayerPrefs.SetString("SkinResult", condition);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ResultScene");
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("HomeScene");
    }
}