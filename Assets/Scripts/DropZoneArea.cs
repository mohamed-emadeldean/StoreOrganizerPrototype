using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropZoneArea : MonoBehaviour
{

    [Header("Accepted Category")]
    public ProductCategory acceptedType;

    [Header("Player Presence")]
    public bool isPlayerInside = false;

    [Header("Drop Spots")]
    public DropSpot[] dropSpots;

    [Header("UI Elements")]
    public Button placeButton;
    public Button submitButton;
    public TextMeshProUGUI win;
    public TextMeshProUGUI tryAgain;
    public Button restartGame;

    public GameObject warningText;

    private void Awake()
    {
        // If you forgot to assign dropSpots manually, grab children automatically:
        if (dropSpots == null || dropSpots.Length == 0)
            dropSpots = GetComponentsInChildren<DropSpot>();

        // hide UI initially
        placeButton?.gameObject.SetActive(false);
        warningText?.SetActive(false);

        // wire up the button click
        if (placeButton != null)
            placeButton.onClick.AddListener(OnPlaceButtonClicked);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            placeButton?.gameObject.SetActive(true);
            warningText?.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            placeButton?.gameObject.SetActive(false);
            warningText?.SetActive(false);
        }
    }

    private void OnPlaceButtonClicked()
    {
        if (!isPlayerInside) return;

        // find the free spot with the lowest index
        var freeSpot = dropSpots
            .OrderBy(s => s.spotIndex)
            .FirstOrDefault(s => !s.isOccupied);

        if (freeSpot == null)
        {
            Debug.LogWarning("No free drop spots left!");
            warningText?.SetActive(true);
            return;
        }

        var held = ProductInstance.currentlySelected;
        if (held == null)
        {
            Debug.Log("No product selected to place.");
            return;
        }

        freeSpot.PlaceProduct(held);

        if (dropSpots.All(s => s.isOccupied))
        {
            Debug.Log("All spots are filled! Run your validation here.");

            submitButton.gameObject.SetActive(true);
        }

    }

    public void OnSubmitButtonClicked()
    {
        bool result = true;

        for (int i = 0; i < dropSpots.Length; i++)
        {
            if (dropSpots[i].occupyingProduct.data.category != acceptedType)
            {
                result = false;
                break;
            }
        }

        if (acceptedType == ProductCategory.Shelf)
            InventoryManager.ShelfPassed = result;
        else if (acceptedType == ProductCategory.Cooler)
            InventoryManager.CoolerPassed = result;

        if (acceptedType == ProductCategory.Shelf)
        {
            SceneManager.LoadScene("CoolerScene");
        }
        else
        {
            if (InventoryManager.ShelfPassed && InventoryManager.CoolerPassed)
            {
                Debug.Log("True");
                win.gameObject.SetActive(true);
            }
            else 
            {
                Debug.Log("False");
                tryAgain.gameObject.SetActive(true);
            }
            submitButton.gameObject.SetActive(false);
            restartGame.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
         
    }

    public void OnRestartButtonClicked()
    {
        InventoryManager.ShelfPassed = false;
        InventoryManager.CoolerPassed = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}