using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイマー
/// </summary>
public class Timer
{
    //タイム
    private float m_time;
    //現在の設定時間
    private float m_currentTime;
    //動いているか
    private bool m_isPlaying;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Timer()
    {
        m_time = 0f;
        m_currentTime = 0f;
        m_isPlaying = false;
    }

    /// <summary>
    /// 開始
    /// </summary>
    public void Start()
    {
        m_isPlaying = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        if (!m_isPlaying) return;

        m_time -= Time.deltaTime;

        m_time = Mathf.Min(m_time, 0f);
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void Stop()
    {
        m_isPlaying = false;
    }

    public void Reset()
    {
        m_isPlaying = false;
        m_time = m_currentTime;
    }

    /// <summary>
    /// タイマーをセット
    /// </summary>
    /// <param name="_time"></param>
    public void SetTime(float _time)
    {
        m_currentTime = _time;
        m_time = m_currentTime;
    }

    /// <summary>
    /// 終了したか？
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_time <= 0f;
    }
}
