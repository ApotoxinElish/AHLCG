using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public TextAsset cardData;
    public Dictionary<int, Card> cardDict = new Dictionary<int, Card>();

    // Start is called before the first frame update
    void Start()
    {
        //LoadCardData();
        //TestLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 根据卡牌类别读取所有卡牌信息
    /// </summary>
    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[1] == "Investigator")
            {
                // 新建调查员卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // int atk = int.Parse(rowArray[3]);
                // int health = int.Parse(rowArray[4]);
                InvestigatorCard investigatorCard = new InvestigatorCard(id, title);
                cardDict.Add(id, investigatorCard);

                Debug.Log("读取到调查员卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Asset")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AssetCard assetCard = new AssetCard(id, title);
                cardDict.Add(id, assetCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Event")
            {
                // 新建事件卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                EventCard eventCard = new EventCard(id, title);
                cardDict.Add(id, eventCard);

                Debug.Log("读取到事件卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Skill")
            {
                // 新建技能卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                SkillCard skillCard = new SkillCard(id, title);
                cardDict.Add(id, skillCard);

                Debug.Log("读取到技能卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Scenario")
            {
                // 新建冒险辅助卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                ScenarioReferenceCard scenarioReferenceCard = new ScenarioReferenceCard(id, title);
                cardDict.Add(id, scenarioReferenceCard);

                Debug.Log("读取到冒险辅助卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Agenda")
            {
                // 新建密谋卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AgendaCard agendaCard = new AgendaCard(id, title);
                cardDict.Add(id, agendaCard);

                Debug.Log("读取到密谋卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Act")
            {
                // 新建场景卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                ActCard actCard = new ActCard(id, title);
                cardDict.Add(id, actCard);

                Debug.Log("读取到场景卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Location")
            {
                // 新建地点卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                LocationCard locationCard = new LocationCard(id, title);
                cardDict.Add(id, locationCard);

                Debug.Log("读取到地点卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Enemy")
            {
                // 新建敌人卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                EnemyCard enemyCard = new EnemyCard(id, title);
                cardDict.Add(id, enemyCard);

                Debug.Log("读取到敌人卡：" + cardDict[id].title);
            }
            else if (rowArray[1] == "Treachery")
            {
                // 新建诡计卡
                int id = int.Parse(rowArray[0]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                TreacheryCard treacheryCard = new TreacheryCard(id, title);
                cardDict.Add(id, treacheryCard);

                Debug.Log("读取到诡计卡：" + cardDict[id].title);
            }
        }
    }

    public void TestLoad()
    {
        foreach (var item in cardDict)
        {
            Debug.Log("卡牌：" + item.Key.ToString() + item.Value.title);
        }
    }

    public Card RandomCard()
    {
        Card card = cardDict[Random.Range(0, cardDict.Count)];
        return card;
    }

    public Card CopyCard(int _id)
    {
        Card copyCard = new Card(_id, cardDict[_id].title);
        if (cardDict[_id] is InvestigatorCard)
        {
            var card = cardDict[_id] as InvestigatorCard;
            copyCard = new InvestigatorCard(_id, card.title);
        }
        else if (cardDict[_id] is AssetCard)
        {
            var card = cardDict[_id] as AssetCard;
            copyCard = new AssetCard(_id, card.title);
        }
        else if (cardDict[_id] is EventCard)
        {
            var card = cardDict[_id] as EventCard;
            copyCard = new EventCard(_id, card.title);
        }
        else if (cardDict[_id] is SkillCard)
        {
            var card = cardDict[_id] as SkillCard;
            copyCard = new SkillCard(_id, card.title);
        }
        else if (cardDict[_id] is ScenarioReferenceCard)
        {
            var card = cardDict[_id] as ScenarioReferenceCard;
            copyCard = new ScenarioReferenceCard(_id, card.title);
        }
        else if (cardDict[_id] is AgendaCard)
        {
            var card = cardDict[_id] as AgendaCard;
            copyCard = new AgendaCard(_id, card.title);
        }
        else if (cardDict[_id] is ActCard)
        {
            var card = cardDict[_id] as ActCard;
            copyCard = new ActCard(_id, card.title);
        }
        else if (cardDict[_id] is LocationCard)
        {
            var card = cardDict[_id] as LocationCard;
            copyCard = new LocationCard(_id, card.title);
        }
        else if (cardDict[_id] is EnemyCard)
        {
            var card = cardDict[_id] as EnemyCard;
            copyCard = new EnemyCard(_id, card.title);
        }
        else if (cardDict[_id] is TreacheryCard)
        {
            var card = cardDict[_id] as TreacheryCard;
            copyCard = new TreacheryCard(_id, card.title);
        }
        // 其他卡牌类型

        return copyCard;
    }
}
