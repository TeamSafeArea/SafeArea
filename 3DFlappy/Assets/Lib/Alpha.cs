using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// α値クラス
/// Yuuho Aritomi
/// 2017/02/12
/// </summary>
public class Alpha
{
    //α値
    private float m_a;
    //デフォルトのα値
    private float m_defaultAlpha;
    //タイム
    private float m_time;
    //フェードインしているか？
    private bool m_isFadeIn;
    //フェードアウトしているか？
    private bool m_isFadeOut;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_intAlpha"></param>
    public Alpha(int _defaultAlpha)
    {
        m_defaultAlpha = _defaultAlpha;
        m_a = m_defaultAlpha;
        m_time = 0;
        m_isFadeIn = false;
        m_isFadeOut = false;
    }

    /// <summary>
    /// 時間を設定
    /// </summary>
    /// <param name="_time"></param>
    public void SetFadeTime(float _time)
    {
        m_time = _time;
    }

    /// <summary>
    /// フェードイン開始
    /// </summary>
    public void FadeInStart()
    {
        m_isFadeIn = true;
        m_isFadeOut = false;
    }

    /// <summary>
    /// フェードアウト開始
    /// </summary>
    public void FadeOutStart()
    {
        m_isFadeIn = false;
        m_isFadeOut = true;
    }

    /// <summary>
    /// フェード停止
    /// </summary>
    public void FadeStop()
    {
        m_isFadeIn = false;
        m_isFadeOut = false;
    }

    /// <summary>
    /// フェードリセット
    /// </summary>
    public void FadeReset()
    {
        m_isFadeIn = false;
        m_isFadeOut = false;
        m_a = m_defaultAlpha;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        FadeIn();

        FadeOut();
    }

    /// <summary>
    /// フェードインが終了しているか？
    /// </summary>
    /// <returns></returns>
    public bool IsEndFadeIn()
    {
        return m_a >= 1;
    }

    /// <summary>
    /// フェードアウトが終了しているか？
    /// </summary>
    /// <returns></returns>
    public bool IsEndFadeOut()
    {
        return m_a <= 0;
    }

    /// <summary>
    /// α値
    /// </summary>
    public float A
    {
        get { return m_a; }
    }

    //フェードイン
    private void FadeIn()
    {
        if (m_isFadeIn == true) return;

        float time = (1 * m_time) / Time.deltaTime;
        m_a += 1 / time;
        m_a = Clamp.clamp(m_a, 0, 1);
    }

    private void FadeOut()
    {
        if (m_isFadeOut == true) return;

        float time = (1 * m_time) / Time.deltaTime;
        m_a -= 1 / time;
        m_a = Clamp.clamp(m_a, 0, 1);
    }
}
