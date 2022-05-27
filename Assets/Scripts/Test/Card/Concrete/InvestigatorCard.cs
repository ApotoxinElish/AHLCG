using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调查员卡
/// </summary>
public class InvestigatorCard : PlayerCard
{
    /// <summary>
    /// 技能
    /// This investigator's value for his or her skills, in order: Willpower, Intellect, Combat, Agility.
    /// </summary>
    public Dictionary<SkillTestIcons, int> skills;
    /// <summary>
    /// 远古印记能力
    /// This investigator's ability for the Elder Sign token.
    /// </summary>
    public string elderSignAbility;
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

    public InvestigatorCard(int _id, string _title) : base(_id, _title)
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
