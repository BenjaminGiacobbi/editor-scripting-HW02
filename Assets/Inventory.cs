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
    

    // returns a JSON array of the current equipment
    private string ConvertToJson()
    {
        if(currentlyEquipped.Length < 1)
        {
            Debug.Log("Equipment Array is empty. Cannot save without equipment data");
            return "";
        }

        string fullJsonString = null;
        for(int item = 0; item < currentlyEquipped.Length; item++)
        {
            fullJsonString += JsonUtility.ToJson(currentlyEquipped[item]);
            if (item != currentlyEquipped.Length - 1)
                fullJsonString += ",";
        }
        fullJsonString = "{\"Equipment\":[" + fullJsonString + "]}";

        return fullJsonString;
    }

    // saves current equipment to a file specified by path
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
        // fill the currentlyEquipped array with the json contents using JsonHelper, for some reason it keeps returning NULL
        reader.Close();
    }
}