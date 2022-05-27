using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 密谋卡
/// </summary>
public class AgendaCard : ScenarioCard
{
    /// <summary>
    /// 密谋编号
    /// Used to order the agenda deck.
    /// </summary>
    public int agendaSequence;
    /// <summary>
    /// 毁灭目标值
    /// The amount of doom in play required to advance this agenda.
    /// </summary>
    public int doomThreshold;

    public AgendaCard(int _id, string _title) : base(_id, _title)
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
