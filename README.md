# StoreOrganizerPrototype

> A Unity prototype demonstrating store-organization mechanics: spawning products, drag-and-drop sorting into category-specific zones, and simple scoring. Includes multi-language support via Unity’s Localization package.

---

## Prerequisites

- **Unity Editor** v2023.3 LTS or later  
- **Android Module**

---

## Getting Started

1. **Clone the repository**  
   ```bash
   git clone https://github.com/mohamed-emadeldean/StoreOrganizerPrototype.git

2. **Clone the repository**     
  - **Launch Unity Hub → Add → select the project folder** 
  - **Open the project in the required Unity version**

---

## Features

- **Random Product Spawning**  
  Products appear randomly in preset locations.

- **Drag-and-Drop Interaction**  
  Pick up and place products using mouse or touch via Unity Simulator.

- **Category-Based Drop Zones**  
  Each drop zone accepts only specific product types.

- **Submission & Scoring**  
  Press submit to check your sorting accuracy and get feedback.

- **Multi-language Support**  
  Switch between languages using a dropdown menu.

---

## Usage

1. **Enter Play Mode** in Unity.
2. **Drag products** into the correct shelf or cooler in the highlighted area.
3. **Click Submit after sorting producs**.
4. **Click submit to advance to the next scene (CoolerScene)** 
---

## Adding New Products

1. Go to `Assets/ScriptableObjects`.
2. Right-click → **Create → ProductData**.
3. Fill in:
   - Name  
   - Category  
   - Prefab
4. Add the new product to the **InventoryManager**'s product list.
---

## Main Scripts Overview

- **InventoryManager.cs**  
  Spawns random products into the scene and holds references to all available items.

- **ProductInstance.cs**  
  Controls drag-and-drop behavior for each product, including selection and placement logic.

- ***DropZoneArea.cs***  
  Handles product placement and validation inside a specific drop zone (Shelf or Cooler).
  
## License

This project is licensed under the **MIT License**.  
See the [LICENSE](LICENSE) file for details.
