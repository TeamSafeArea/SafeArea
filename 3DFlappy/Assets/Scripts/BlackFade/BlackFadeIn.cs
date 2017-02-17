using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 黒フェードイン
/// Yuuho Aritomi
/// 2017/02/13
/// </summary>
public class BlackFadeIn : MonoBehaviour
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
        m_a = 0f;
    }

    /// <summary>
    /// 終了しているか？
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_a >= 1f;
    }

    //開始
    void Start()
    {
        m_isWorking = false;
        m_a = 0f;
    }

    //更新
    void Update()
    {
        if (m_isWorking == false) return;

        if (m_fadeTime <= 0)
        {
            SetAlpha(1);
        }
        m_a += Time.deltaTime / m_fadeTime;
        m_a = Mathf.Min(m_a, 1);
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
