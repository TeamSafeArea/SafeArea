using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ブラックフェードアウト
/// Yuuho Aritomi
/// 2017/02/14
/// </summary>
public class BlackFadeOut : MonoBehaviour
{
    //フェード時間
    [SerializeField]
    private float m_fadeTime;
    //動いているか？
    [SerializeField]
    private bool m_isWorking;
    //α値
    private float m_a;

    /// <summary>
    /// フェードスタート
    /// </summary>
    public void StartAnimation()
    {
        m_isWorking = true;
    }

    /// <summary>
    /// 再設定
    /// </summary>
    public void Reset()
    {
        m_isWorking = false;
        m_a = 1f;
    }

    /// <summary>
    /// 終了しているか？
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_a <= 0f;
    }

    //開始
    void Start()
    {
        Reset();
    }

    //更新
    void Update()
    {
        if (m_isWorking == false) return;

        if (m_fadeTime <= 0)
        {
            SetAlpha(0);
        }
        m_a -= Time.deltaTime / m_fadeTime;
        m_a = Mathf.Max(m_a, 0);
        SetAlpha(m_a);
    }

    //α値を設定
    private void SetAlpha(float _alpha)
    {
        Image image = GetComponent<Image>();
        Color color = image.color;
        color.a = _alpha;
        image.color = color;
    }
}
