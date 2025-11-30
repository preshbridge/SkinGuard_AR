using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDisplay : MonoBehaviour
{
    // Use regular UI.Image (not RawImage) for Sprite support
    public Text resultText;
    public Text tipsText;
    public Image resultImage; // ← Image, not RawImage

    // Assign Sprites in Inspector (PNGs must be set to Sprite type)
    public Sprite healthySprite;
    public Sprite acneSprite;
    public Sprite rashSprite;

    void Start()
    {
        string condition = PlayerPrefs.GetString("SkinResult", "Healthy");

        // Always assign text — even if fields are missing, this won't crash
        if (resultText != null)
        {
            resultText.text = condition switch
            {
                "Acne" => "Acne Detected",
                "Rash" => "Skin Rash Detected",
                _ => "Healthy Skin!"
            };
        }

        if (tipsText != null)
        {
            tipsText.text = condition switch
            {
                "Acne" => "• Wash face twice daily\n• Avoid touching your face\n• Use non-comedogenic products",
                "Rash" => "• Avoid scratching the area\n• Use fragrance-free moisturizers\n• Consult a doctor if it spreads",
                _ => "• Keep moisturizing\n• Stay hydrated\n• Protect from sun exposure"
            };
        }

        if (resultImage != null)
        {
            resultImage.sprite = condition switch
            {
                "Acne" => acneSprite,
                "Rash" => rashSprite,
                _ => healthySprite
            };
        }
    }

    public void OnBackToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}