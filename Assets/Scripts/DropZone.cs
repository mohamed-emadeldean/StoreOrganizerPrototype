using UnityEngine;
using System.Collections.Generic;

public class DropZone : MonoBehaviour
{
    [Header("Accepted Category")]
    public ProductCategory acceptedType;   // Set this to Shelf or Cooler in the Inspector

    [Header("Placed Items")]
    public List<ProductInstance> placedItems = new List<ProductInstance>();

    private void OnTriggerEnter(Collider other)
    {
        ProductInstance product = other.GetComponent<ProductInstance>();
        if (product != null && !placedItems.Contains(product))
        {
            placedItems.Add(product);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ProductInstance product = other.GetComponent<ProductInstance>();
        if (product != null && placedItems.Contains(product))
        {
            placedItems.Remove(product);
        }
    }
}