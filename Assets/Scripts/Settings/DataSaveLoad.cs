using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataSaveLoad : MonoBehaviour
{
    [System.Serializable]
    private class DataSaver
    {
        public int coalOreAmount;
        public int goldCoins;
    }

    public void SaveData(int coalOreAmount, int goldCoins)
    {
        DataSaver data = new DataSaver();
        data.coalOreAmount = coalOreAmount;
        data.goldCoins = goldCoins;

        string jsonData = JsonUtility.ToJson(data);
        // TODO:
        //File.WriteAllText(Application.persistentDataPath + "/Savedata.json", jsonData);
        File.WriteAllText("C:/Users/Joonas/Desktop/Projects/ProjectT/Savedata/Savedata.json", jsonData);
    }

    public (int, int) LoadData()
    {   
        // TODO:
        //string path = Application.persistentDataPath + "/Savedata.json";
        string path = "C:/Users/Joonas/Desktop/Projects/ProjectT/Savedata/Savedata.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            DataSaver data = JsonUtility.FromJson<DataSaver>(jsonData);
            // TODO: Return DataSaver class (values are inside it) and not values separately.
            return (data.coalOreAmount, data.goldCoins);
        }
        throw new FileNotFoundException("File not Found! Wrong path or file deleted? Or no read perm?");
    }
}
