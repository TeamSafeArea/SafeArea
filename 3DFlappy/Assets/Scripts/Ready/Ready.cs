using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// レディ
/// Yuuho Aritomi
/// 2017/02/14
/// </summary>
public class Ready : MonoBehaviour
{
    //最初の時間
    [SerializeField]
    private float m_firstTime;
    //次の時間
    [SerializeField]
    private float m_secondTime;
    //最後の時間
    [SerializeField]
    private float m_thirdTime;
    //開始時の時間
    private float m_startTime;
    //開始時の位置
    private Vector3 m_startPosition;
    //終わりの位置
    private Vector3 m_endPosition;
    //ステップ
    private int m_step;
    //アニメーションし終わったか？
    private bool m_isEnd;
    //動いているか？
    private bool m_isWorking;

    /// <summary>
    /// アニメーションを開始する
    /// </summary>
    public void StartAnimation()
    {
        m_isWorking = true;
    }

    /// <summary>
    /// 終了したか？
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_isEnd;
    }

    //開始
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        m_startPosition = rectTransform.localPosition;
        m_endPosition = -m_startPosition;
        m_step = 0;
    }

    //更新
    void Update()
    {
        if (m_isWorking == false) return;

        switch (m_step)
        {
            case 0:
                m_startTime = Time.time;
                m_step++;
                break;
            case 1:
                first();
                break;
            case 2:
                second();
                break;
            case 3:
                third();
                break;
            default:
                break;
        }
    }

    //最初のアニメーション
    private void first()
    {
        float timeStep = m_firstTime > 0f ? (Time.time - m_startTime) / m_firstTime : 1.0f;
        Mathf.Clamp01(timeStep);
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 position = rectTransform.localPosition;
        GetComponent<RectTransform>().localPosition = Vector3.Lerp(m_startPosition, Vector3.zero, timeStep);

        if (timeStep >= 1)
        {
            m_step++;
            m_startTime = Time.time;
        }
    }

    //次のアニメーション
    private void second()
    {
        float timeStep = m_secondTime > 0f ? (Time.time - m_startTime) / m_secondTime : 1.0f;
        Mathf.Clamp01(timeStep);

        if (timeStep >= 1)
        {
            m_step++;
            m_startTime = Time.time;
        }
    }

    //最後のアニメーション
    private void third()
    {
        float timeStep = m_thirdTime > 0f ? (Time.time - m_startTime) / m_thirdTime : 1.0f;
        Mathf.Clamp01(timeStep);
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 position = rectTransform.localPosition;
        GetComponent<RectTransform>().localPosition = Vector3.Lerp(Vector3.zero, m_endPosition, timeStep);

        if (timeStep >= 1)
        {
            m_isEnd = true;
        }
    }
}
