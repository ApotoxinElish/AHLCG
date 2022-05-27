using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum GamePhase
{
    mythosPhase, investigationPhase, enemyPhase, upkeepPhase
}

public class RoundManager : MonoSingleton<RoundManager>
{
    public PlayerData playerData;
    // public PlayerData enemyData;//数据

    public List<Card> playerDeckList = new List<Card>();
    // public List<Card> enemyDeckList = new List<Card>();// 卡组

    public GameObject cardPrefab;// 卡牌

    public Transform playerHand;

    public GamePhase GamePhase = GamePhase.investigationPhase;

    public UnityEvent phaseChangeEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //游戏流程
    //开始游戏：加载数据，卡组洗牌，初始手牌
    //回合结束，游戏阶段
    public void GameStart()
    {
        // 读取数据
        ReadDeck();

        // 卡组洗牌
        ShuffleDeck(0);

        // 玩家抽卡5，敌人抽卡5
        DrawCard(0, 5);
    }

    public void ReadDeck()
    {
        // 加载玩家卡组
        for (int i = 0; i < playerData.playerDeck.Count; i++)
        {
            playerDeckList.Add(playerData.DataManager.CopyCard(playerData.playerDeck[i]));
        }

        // 加载敌人卡组
        // for (int i = 0; i < enemyData.playerDeck.Count; i++)
        // {
        //     if (enemyData.playerDeck[i] != 0)
        //     {
        //         int count = enemyData.playerDeck[i];
        //         for (int j = 0; j < count; j++)
        //         {
        //             enemyDeckList.Add(enemyData.CardStore.CopyCard(i));
        //         }
        //     }
        // }
    }

    public void ShuffleDeck(int _player)// 0为玩家，1为敌人
    {
        List<Card> shuffleDeck = new List<Card>();
        if (_player == 0)
        {
            shuffleDeck = playerDeckList;
        }
        // else if (_player == 1)
        // {
        //     shuffleDeck = enemyDeckList;
        // }

        for (int i = 0; i < shuffleDeck.Count; i++)
        {
            int rad = Random.Range(0, shuffleDeck.Count);
            Card temp = shuffleDeck[i];
            shuffleDeck[i] = shuffleDeck[rad];
            shuffleDeck[rad] = temp;
        }
    }

    public void OnPlayerDraw()
    {
        if (GamePhase == GamePhase.investigationPhase)
        {
            DrawCard(0, 1);
            // NextPhase();
        }
    }

    public void DrawCard(int _player, int _count)
    {
        List<Card> drawDeck = new List<Card>();
        Transform hand = transform;
        if (_player == 0)
        {
            drawDeck = playerDeckList;
            hand = playerHand;
        }
        // else if (_player == 1)
        // {
        //     drawDeck = enemyDeckList;
        //     hand = enemyHand;
        // }

        for (int i = 0; i < _count; i++)
        {
            GameObject card = Instantiate(cardPrefab, hand);
            // card.GetComponent<CardDisplay>().card = drawDeck[0];
            string name = drawDeck[0].id.ToString().PadLeft(5, '0');
            Debug.Log(name);
            Sprite cardImg = Resources.Load("Images/Cards/" + name, typeof(Sprite)) as Sprite;
            card.transform.Find("BackgroundImage").GetComponent<Image>().sprite = cardImg;
            // card.GetComponent<BattleCard>().playerID = _player;
            drawDeck.RemoveAt(0);
        }
    }

    public void OnClickTurnEnd()
    {
        TurnEnd();
    }

    public void TurnEnd()
    {
        if (GamePhase == GamePhase.investigationPhase)
        {
            NextPhase();
        }
    }

    public void NextPhase()
    {
        if ((int)GamePhase == System.Enum.GetNames(GamePhase.GetType()).Length - 1)
        {
            GamePhase = GamePhase.mythosPhase;
        }
        else
        {
            GamePhase += 1;
        }
        phaseChangeEvent.Invoke();
    }
}
