using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム管理
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    BlackFadeOut m_blackFadeOut;
    [SerializeField]
    Ready m_ready;

    /// <summary>
    /// プレイが可能か？
    /// </summary>
    /// <returns></returns>
    public bool IsPlay()
    {
        return m_ready.IsEnd();
    }

    //開始
    void Start()
    {
    }

    //更新
    void Update()
    {
        m_blackFadeOut.StartAnimation();

        if(m_blackFadeOut.IsEnd() == true)
        {
            m_ready.StartAnimation();
        }
    }
}
