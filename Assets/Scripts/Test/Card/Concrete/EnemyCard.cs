using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人卡
/// </summary>
public class EnemyCard : ScenarioCard
{
    /// <summary>
    /// 敌人攻击值
    /// Determines the difficulty of a skill test to attack this enemy.
    /// </summary>
    public int enemyFightValue;
    /// <summary>
    /// 敌人生命值
    /// This enemy's health value, which measures its physical durability.
    /// </summary>
    public int enemyHealthValue;
    public int enemyHealthValueMax;
    /// <summary>
    /// 敌人躲避值
    /// Determines the difficulty of a skill test to evade this enemy.
    /// </summary>
    public int enemyEvadeValue;
    /// <summary>
    /// 伤害
    /// The amount of damage this enemy deals with its attack.
    /// </summary>
    public int damage;
    /// <summary>
    /// 恐惧
    /// The amount of horror this enemy deals with its attack.
    /// </summary>
    public int horror;

    public EnemyCard(int _id, string _title) : base(_id, _title)
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
