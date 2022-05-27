using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 支援卡
/// </summary>
public class AssetCard : PlayerCard
{
    /// <summary>
    /// 费用
    /// The resource cost to play a card.
    /// </summary>
    public int cost;
    /// <summary>
    /// 生命值
    /// This card's health value, which measures its physical durability.
    /// </summary>
    public int health;
    public int healthMax;
    /// <summary>
    /// 神智值
    /// This card's sanity value, which measures its mental durability.
    /// </summary>
    public int sanity;
    public int sanityMax;

    public Dictionary<Slot, int> slot;

    public AssetCard(int _id, string _title) : base(_id, _title)
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
