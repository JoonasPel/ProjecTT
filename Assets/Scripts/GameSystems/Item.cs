using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    public int itemID;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public int weight;
}
