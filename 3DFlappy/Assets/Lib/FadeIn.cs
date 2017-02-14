using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フェードインクラス
/// Yuuho Aritomi
/// 2017/02/13
/// </summary>
public class FadeIn
{
    //α値
    private float m_alpha;
    //動作しているか？
    private bool m_isWorking;
    //フェードするの時間
    private float m_fadeTime;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FadeIn()
    {
        m_alpha = 0f;
        m_fadeTime = 0f;
    }

    /// <summary>
    /// 時間を設定
    /// </summary>
    /// <param name="_time"></param>
    public void SetTime(float _time)
    {
        m_fadeTime = _time;
    }

    /// <summary>
    /// 開始
    /// </summary>
    public void Start()
    {
        m_isWorking = true;
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        m_alpha = 0f;
        m_isWorking = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        if (m_isWorking == false) return;

        float time = 1 * m_fadeTime;
        m_alpha += 1 / time;
        m_alpha = Clamp.clamp(m_alpha, 0, 1);
    }
}
