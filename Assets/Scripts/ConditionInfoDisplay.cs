using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConditionInfoDisplay : MonoBehaviour
{
    public Text infoTitleText;
    public Text infoDetailsText;
    public Button backButton;

    void Start()
    {
        string condition = PlayerPrefs.GetString("InfoCondition", "Healthy");

        if (infoTitleText != null)
        {
            infoTitleText.text = condition switch
            {
                "Acne" => "About Acne",
                "Rash" => "About Skin Rashes",
                _ => "About Healthy Skin"
            };
        }

        if (infoDetailsText != null)
        {
            infoDetailsText.text = condition switch
            {
                "Acne" =>
                    "Acne is a common skin condition caused by clogged pores, excess oil, bacteria, and hormones.\n\n" +
                    "Common in teens and young adults.\n\n" +
                    "When to see a doctor:\n" +
                    "• Severe or painful acne\n" +
                    "• Scarring\n" +
                    "• No improvement after 3 months of self-care",

                "Rash" =>
                    "A rash is a change in skin color, texture, or sensation, often due to allergy, infection, or irritation.\n\n" +
                    "Common triggers:\n" +
                    "• Soaps, detergents\n" +
                    "• Plants (e.g., poison ivy)\n" +
                    "• Heat or friction\n\n" +
                    "Seek medical help if:\n" +
                    "• Rash spreads quickly\n" +
                    "• Fever or pain present\n" +
                    "• Blisters or pus",

                _ =>
                    "Healthy skin is resilient, well-hydrated, and free from irritation.\n\n" +
                    "Maintenance Tips:\n" +
                    "• Cleanse gently\n" +
                    "• Moisturize daily\n" +
                    "• Use sunscreen (SPF 30+)\n" +
                    "• Eat balanced diet\n" +
                    "• Drink plenty of water\n\n" +
                    "Regular skin checks help catch issues early!"
            };
        }

        // Auto-wire back button if assigned
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(OnBackToHome);
        }
    }

    // ✅ PUBLIC method so it appears in Unity's OnClick() dropdown
    public void OnBackToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}