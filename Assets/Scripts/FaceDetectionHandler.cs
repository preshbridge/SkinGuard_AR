using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaceDetectionHandler : MonoBehaviour
{
    [Header("UI")]
    public RawImage cameraPreview;
    public GameObject scanButton;
    public GameObject backButton;

    private WebCamTexture webcam;
    private bool hasScanned = false;

    void Start()
    {
        // 🔁 Always reset when scene loads
        hasScanned = false;
        if (scanButton != null)
            scanButton.SetActive(false);
        SetupCamera();
    }

    void SetupCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Invoke(nameof(GoToHome), 2f);
            return;
        }

        string camName = "";
        foreach (var device in devices)
        {
            if (device.isFrontFacing)
            {
                camName = device.name;
                break;
            }
        }
        if (string.IsNullOrEmpty(camName))
            camName = devices[0].name;

        webcam = new WebCamTexture(camName, 1280, 720);
        cameraPreview.texture = webcam;
        webcam.Play();

        Invoke(nameof(ShowScanButton), 2f);
    }

    void ShowScanButton()
    {
        if (!hasScanned && scanButton != null)
            scanButton.SetActive(true);
    }

    public void OnScanButtonPressed()
    {
        if (hasScanned) return;
        hasScanned = true;

        float r = Random.value;
        string condition = r switch
        {
            < 0.5f => "Acne",
            < 0.8f => "Rash",
            _ => "Healthy"
        };

        PlayerPrefs.SetString("SkinResult", condition);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ResultScene");
    }

    public void OnBackButtonPressed()
    {
        if (webcam != null && webcam.isPlaying)
            webcam.Stop();
        SceneManager.LoadScene("HomeScene");
    }

    void GoToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    void OnDestroy()
    {
        if (webcam != null && webcam.isPlaying)
            webcam.Stop();
    }
}