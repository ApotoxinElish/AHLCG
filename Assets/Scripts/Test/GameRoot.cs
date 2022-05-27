using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 管理全局的一些东西
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    /// <summary>
    /// 场景管理器
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }
    /// <summary>
    /// 显示一个面板
    /// </summary>
    public UnityAction<BasePanel> Push { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        SceneSystem = new SceneSystem();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }

    /// <summary>
    /// 设置Push
    /// </summary>
    /// <param name="push"></param>
    public void SetAction(UnityAction<BasePanel> push)
    {
        Push = push;
    }
}
