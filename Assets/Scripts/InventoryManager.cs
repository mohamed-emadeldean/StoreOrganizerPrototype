using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [Header("Data Source")]
    public List<ProductData> allProducts;     // Assign in Inspector

    [Header("Spawn Settings")]
    public int itemCount;                 // Number of products to spawn
    public Transform[] spawnPoints;           // Assign spawn positions in Inspector

    public static bool ShelfPassed;
    public static bool CoolerPassed;
    void Start()
    {
        SpawnRandomProducts();
    }

    void SpawnRandomProducts()
    {
        // Safety check
        if (allProducts.Count == 0 || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No products or spawn points assigned.");
            return;
        }

        // Shuffle the product list and take the first N items
        var selectedProducts = allProducts
            .OrderBy(_ => Random.value)
            .Take(Mathf.Min(itemCount, spawnPoints.Length))
            .ToList();

        for (int i = 0; i < selectedProducts.Count; i++)
        {
            var data = selectedProducts[i];
            var point = spawnPoints[i];

            // Instantiate the product model (from ProductData)
            GameObject instance = Instantiate(data.modelPrefab, point.position, point.rotation);

            // Assign the data to the instance
            var productInstance = instance.GetComponent<ProductInstance>();
            if (productInstance != null)
            {
                productInstance.Setup(data, point);
            }
        }
    }
}