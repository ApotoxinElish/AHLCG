using System.Collections.Generic;

// /// <summary>
// /// 卡牌类型
// /// </summary>
// public enum Cardtype
// {
//     investigatorCard,
//     assetCard, eventCard, skillCard,
//     scenarioCard, agendaCard, actCard, locationCard,
//     enemyCard, treacheryCard
// }

public enum SubType
{
    nonWeakness, basicWeakness, weakness
}

/// <summary>
/// 职阶符号
/// </summary>
public enum ClassSymbol
{
    neutral, guardian, seeker, mystic, rogue, survivor
}

/// <summary>
/// 技能检定图标
/// </summary>
public enum SkillTestIcons
{
    wild, willpower, intellect, combat, agility
}

public enum Slot
{
    nonSlot, ally, body, accessory, hand, arcane
}

/// <summary>
/// 卡牌
/// </summary>
public class Card
{
    public int id;
    // /// <summary>
    // /// 卡牌类型
    // /// Indicates how a card behaves or may be used in the game.
    // /// </summary>
    // public Cardtype cardtype;
    public SubType subType;
    /// <summary>
    /// 名称
    /// The name of this card.
    /// </summary>
    public string title;
    /// <summary>
    /// 副名称
    /// A secondary identifier for a card.
    /// </summary>
    public string subtitle;
    /// <summary>
    /// 属性
    /// Flavorful attributes that may be referenced by card abilities.
    /// </summary>
    public List<string> traits;
    /// <summary>
    /// 能力
    /// This card's specialized means of interacting with the game.
    /// </summary>
    public string ability;
    /// <summary>
    /// 产品图标
    /// Indicates this card's product of origin.
    /// </summary>
    public int productSetInformation;

    public Card(int _id, string _title)
    {
        this.id = _id;
        this.title = _title;
    }
}

/// <summary>
/// 玩家卡
/// </summary>
public class PlayerCard : Card
{
    /// <summary>
    /// 等级
    /// The amount of experience required to purchase this card for a deck.
    /// </summary>
    public int level;
    /// <summary>
    /// 职阶符号
    /// The class to which a card belongs. Neutral cards have no class symbol.
    /// </summary>
    public ClassSymbol classSymbol;
    /// <summary>
    /// 技能检定图标
    /// Modify skill value while committed to a skill test.
    /// </summary>
    public Dictionary<SkillTestIcons, int> skillTestIcons;

    public PlayerCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 冒险卡
/// </summary>
public class ScenarioCard : Card
{
    /// <summary>
    /// 遭遇组符号
    /// Indicates which encounter set the card belongs to.
    /// </summary>
    public string encounterSetSymbol;
    /// <summary>
    /// 遭遇组牌数
    /// Indicates the number of cards within an encounter set, and this card's place within that set.
    /// </summary>
    public int encounterSetNumber;

    public ScenarioCard(int _id, string _title) : base(_id, _title)
    {

    }
}
