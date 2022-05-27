using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景卡
/// </summary>
public class ActCard : ScenarioCard
{
    /// <summary>
    /// 场景编号
    /// Used to order the act deck.
    /// </summary>
    public int actSequence;
    /// <summary>
    /// 线索目标值
    /// The number of clues that must be spent to advance this act.
    /// </summary>
    public int clueThreshold;

    public ActCard(int _id, string _title) : base(_id, _title)
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
