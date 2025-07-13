using UnityEngine;
using TMPro;

public class SelectionUIManager : MonoBehaviour
{
    public static SelectionUIManager Instance { get; private set; }

    [Header("UI Reference")]
    public TextMeshProUGUI productNameText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void UpdateProductName(string name)
    {
        if (productNameText != null)
        {
            productNameText.text = $"Selected: {name}";
        }
    }
}