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
    [SerializeField]
    private HP_UI m_playerHP;
    [SerializeField]
    private HP_UI m_enemyHP;
    [SerializeField]
    private EndingSprites m_endingSprites;
    private bool m_isPlay;

    /// <summary>
    /// プレイが可能か？
    /// </summary>
    /// <returns></returns>
    public bool IsPlay()
    {
        return m_isPlay == true;
    }

    //開始
    void Start()
    {
        m_isPlay = false;
    }

    //更新
    void Update()
    {
        m_blackFadeOut.StartAnimation();

        if(m_blackFadeOut.IsEnd() == true)
        {
            m_ready.StartAnimation();
        }

        if (m_ready.IsEnd() == true)
        {
            m_isPlay = true;
        }

        PlayerDead();

        EnemyDead();
    }

    private void PlayerDead()
    {
        if (m_playerHP.IsDead() == false) return;

        m_endingSprites.SetEndingBeginFlag(true, true);
        m_isPlay = false;
    }

    private void EnemyDead()
    {
        if (m_enemyHP.IsDead() == false) return;

        m_endingSprites.SetEndingBeginFlag(true, false);
        m_isPlay = false;
    }
}
