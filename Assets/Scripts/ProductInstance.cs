using Unity.VisualScripting;
using UnityEngine;

public class ProductInstance : MonoBehaviour
{
    public ProductData data;
    public static ProductInstance currentlySelected;
    public DropSpot currentDropSpot = null;
    public bool isHeld = false;
    public Transform spawnPoint = null;
    public void Setup(ProductData productData, Transform origin)
    {
        data = productData;
        spawnPoint = origin;
    }

    public void OnTapped()
    {
        Debug.Log($"{data.productName} selected.");
        if (currentlySelected != null)
        {
            currentlySelected.transform.position = currentlySelected.spawnPoint.position;
            currentlySelected.transform.rotation = currentlySelected.spawnPoint.rotation;
        }
        if (currentDropSpot != null)
        {
            currentDropSpot.RemoveProduct();
            currentDropSpot = null;
        }
        // 1) Unhide any previously hidden product
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.Show(true);

        }
        // 2) Update your UI
        SelectionUIManager.Instance.UpdateProductName(data.productName);
        Debug.Log($"{data.productName} selected.");

        // 3) Hide this one
        Show(false);

        // 4) Mark as current
        currentlySelected = this;
    }
    public void Show(bool isVisible)
    {
        isHeld = !isVisible;
        gameObject.SetActive(isVisible);
         
    }
}