using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;


[Serializable]
public class Equipment
{
    public string itemName;
    public int statValue;
    public Rarity itemRarity;
    public Slot itemSlot; 
}

public enum Rarity { Common, Uncommon, Rare, UltraRare, Legendary }

public enum Slot { Helmet, Chest, Gauntlet, Greaves, Boots }

public class Inventory : MonoBehaviour
{
    public Equipment[] currentlyEquipped;

    // returns a json representation of the current equipment array
    private string ConvertToJson()
    {
        // informs designer about the conditions of save usage
        if(currentlyEquipped.Length < 1)
        {
            Debug.Log("Equipment Array is empty. Cannot save without equipment data");
            return "";
        }

        // constructs the json form of the inventory data
        string fullJsonString = null;
        for(int item = 0; item < currentlyEquipped.Length; item++)
        {
            fullJsonString += JsonUtility.ToJson(currentlyEquipped[item]);
            if (item != currentlyEquipped.Length - 1)
                fullJsonString += ",";
        }

        // returns
        return fullJsonString;
    }

    // retrieves Json form of inventory data and saves it to a file of specified path
    public void SaveToFile(string path)
    {
        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.Write(ConvertToJson());
        streamWriter.Close();
    }

    public void LoadJsonArray(string path)
    {
        StreamReader reader = new StreamReader(path);
        string jsonContents = reader.ReadToEnd();
        currentlyEquipped = JsonHelper.GetJsonArray<Equipment>(jsonContents);
        reader.Close();
    }
}