using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始主面板
/// </summary>
public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";

    public StartPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        GameObject main_menu = UITool.FindChildGameObject("Main Menu");
        GameObject more = UITool.FindChildGameObject("More");

        UITool.GetOrAddComponentInChildren<Button>("BtnNewGame").onClick.AddListener(() =>
        {
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnMore").onClick.AddListener(() =>
        {
            main_menu.SetActive(false);
            more.SetActive(true);
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnQuit").onClick.AddListener(() =>
        {
            // GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });

        UITool.GetOrAddComponentInChildren<Button>("BtnMainMenu").onClick.AddListener(() =>
        {
            more.SetActive(false);
            main_menu.SetActive(true);
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnOptions").onClick.AddListener(() =>
        {
            Push(new OptionsPanel());
        });

        more.SetActive(false);
    }
}
