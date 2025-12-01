using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDisplay : MonoBehaviour
{
    public Text resultText;
    public Text tipsText;
    public RawImage resultImage;

    public Texture2D healthyTexture;
    public Texture2D acneTexture;
    public Texture2D rashTexture;

    public Button readMoreButton;
    public Button backButton;

    void Start()
    {
        string result = PlayerPrefs.GetString("SkinResult", "Healthy");

        if (resultText != null)
            resultText.text = result switch
            {
                "Acne" => "Acne Detected",
                "Rash" => "Skin Rash Detected",
                _ => "Healthy Skin!"
            };

        if (tipsText != null)
            tipsText.text = result switch
            {
                "Acne" => "• Wash face twice daily\n• Avoid touching your face\n• Use non-comedogenic products",
                "Rash" => "• Avoid scratching the area\n• Use fragrance-free moisturizers\n• Consult a doctor if it spreads",
                _ => "• Keep moisturizing\n• Stay hydrated\n• Protect from sun exposure"
            };

        if (resultImage != null)
            resultImage.texture = result switch
            {
                "Acne" => acneTexture,
                "Rash" => rashTexture,
                _ => healthyTexture
            };

        if (readMoreButton != null)
        {
            readMoreButton.onClick.RemoveAllListeners();
            readMoreButton.onClick.AddListener(OnReadMorePressed);
        }

        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(OnBackToHome);
        }
    }

    public void OnReadMorePressed()
    {
        string condition = PlayerPrefs.GetString("SkinResult", "Healthy");
        PlayerPrefs.SetString("InfoCondition", condition);
        PlayerPrefs.Save();
        SceneManager.LoadScene("InfoScene");
    }

    public void OnBackToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}