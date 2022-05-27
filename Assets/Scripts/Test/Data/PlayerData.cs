using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public DataManager DataManager;
    public List<int> playerDeck;

    public TextAsset playerData;

    // Start is called before the first frame update
    void Awake()
    {
        DataManager.LoadCardData();
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPlayerData()
    {
        // int deckSize = 30;
        playerDeck = new List<int>();

        // Debug.Log("Deck Size: " + playerDeck.Count);
        string[] dataRow = playerData.text.Split('\n');

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            // Debug.Log(rowArray[0]);
            int id = int.Parse(rowArray[0]);
            int num = int.Parse(rowArray[1]);
            //载入卡组
            for (int i = 0; i < num; i++)
                playerDeck.Add(id);
        }
        // int j = playerDeck[0];
        // playerDeck.Remove(j);
        // Debug.Log(playerDeck.Count);
    }

    public void SavePlayerData()
    {
        string path = Application.dataPath + "/Datas/PlayerData.csv";

        List<string> datas = new List<string>();
        Dictionary<int, int> dataDict = new Dictionary<int, int>();
        // 保存卡组
        foreach (var item in playerDeck)
        {
            if (dataDict.ContainsKey(item))
            {
                dataDict[item] += 1;
            }
            else
            {
                dataDict.Add(item, 1);
            }
        }

        foreach (var item in dataDict)
        {
            datas.Add(item.Key.ToString() + "," + item.Value.ToString());
        }

        //保存数据
        File.WriteAllLines(path, datas);
        //Debug.Log(datas);
    }
}
