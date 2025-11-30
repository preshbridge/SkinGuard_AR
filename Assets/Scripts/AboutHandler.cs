using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutHandler : MonoBehaviour
{
    public void OnBackToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}