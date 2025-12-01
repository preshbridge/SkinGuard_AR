using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuHandler : MonoBehaviour
{
    public void GoToScanScene()
    {
        SceneManager.LoadScene("ScanScene");
    }

    public void GoToAboutScene()
    {
        SceneManager.LoadScene("AboutScene");
    }
}