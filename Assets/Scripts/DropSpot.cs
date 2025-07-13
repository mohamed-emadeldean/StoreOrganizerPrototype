using UnityEngine;
using Lean.Common;
using Lean.Touch;

public class DropSpot : MonoBehaviour
{
    [Header("Dependencies")]
    public DropZoneArea dropZoneArea;   // assign the scene instance in Inspector

    [Header("Settings")]
    [Tooltip("Order in which this spot will be filled")]
    public int spotIndex = 0;

    [Tooltip("Drag in your Select component (e.g. LeanSelectByFinger) here")]
    public LeanSelect selectComponent;


    public bool isOccupied = false;

    public ProductInstance occupyingProduct = null;

    /// <summary>
    /// Called when the player taps this spot.
    /// If there’s something here, pick it back up.
    /// </summary>
    public void OnTapped()
    {
        if (!isOccupied)
        {
            Debug.Log($"[DropSpot #{spotIndex}] Nothing to pick up.");
            return;
        }

        // 1) Grab the product that was here
        var product = occupyingProduct;

        // 2) Free the spot
        RemoveProduct();

        // 3) Put it back in the player’s hand
        ProductInstance.currentlySelected = product;
    }
    public void PlaceProduct(ProductInstance product)
    {
        // 1) Move & unhide
        product.transform.position = transform.position;
        product.transform.rotation = transform.rotation;
        product.Show(true);

        // 2) Mark occupied
        isOccupied = true;
        occupyingProduct = product;

        occupyingProduct.currentDropSpot = this;
        // 3) Clear selection
        ProductInstance.currentlySelected = null;
        selectComponent.DeselectAll();
        Debug.Log($"[DropSpot #{spotIndex}] Placed {product.data.productName}");
    }
    public void RemoveProduct()
    {
        if (!isOccupied) return;

        isOccupied = false;
        occupyingProduct = null;

        Debug.Log($"[DropSpot #{spotIndex}] Freed");
    }
}