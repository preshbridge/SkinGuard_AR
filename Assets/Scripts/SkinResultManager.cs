using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinResultManager : MonoBehaviour
{
    public static SkinResultManager Instance;

    public ScanMode CurrentMode { get; private set; }
    public SkinCondition DetectedCondition { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // === FACE SCAN (uses your existing "ScanScene") ===
    public void StartFaceScan()
    {
        CurrentMode = ScanMode.Face;
        SceneManager.LoadScene("ScanScene"); // ✅ You HAVE this scene
    }

    // === BODY SCAN (Optional: disable or repurpose later) ===
    public void StartBodyScan()
    {
        // For now: show a message or reuse ScanScene
        // You can implement real body scanning later

        Debug.Log("💡 Body scanning not implemented yet. Reusing face scan for demo.");
        CurrentMode = ScanMode.Body;
        SceneManager.LoadScene("ScanScene"); // Temporarily use same scene
    }

    // === ABOUT SCREEN ===
    public void OpenAbout()
    {
        SceneManager.LoadScene("AboutScene");
    }

    // === RESULT MANAGEMENT ===
    public void SetResult(SkinCondition condition)
    {
        DetectedCondition = condition;
    }
}