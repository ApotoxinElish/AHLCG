using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地点卡
/// </summary>
public class LocationCard : ScenarioCard
{
    /// <summary>
    /// 隐藏值
    /// Determines the difficulty of a skill test to investigate this location.
    /// </summary>
    public int shroud;
    /// <summary>
    /// 线索值
    /// The number of clues placed on this location when it is first revealed.
    /// </summary>
    public int clueValue;
    /// <summary>
    /// 连接符号
    /// Indicate the movement connections between locations.
    /// </summary>
    public List<string> connectionSymbols;

    public bool unrevealed;

    public LocationCard(int _id, string _title) : base(_id, _title)
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
