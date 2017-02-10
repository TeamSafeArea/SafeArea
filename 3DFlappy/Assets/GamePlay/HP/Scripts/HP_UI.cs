using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HP_UIクラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class HP_UI : MonoBehaviour
{
    //HPコンテナ
    [SerializeField]
    private List<GameObject> m_hpContainer;
    //現在のＨＰ
    private int m_currentHP;

    //開始
    void Start()
    {
        m_currentHP = m_hpContainer.Count;
    }

    //更新
    void Update()
    {
    }

    /// <summary>
    /// ライフをx回復する
    /// </summary>
    /// <param name="_x"></param>
    public void Heal(int _x)
    {
        if (m_hpContainer.Count == 0) return;

        m_currentHP += _x;
        m_currentHP = Mathf.Min(m_currentHP, m_hpContainer.Count);

        UpdateHP();
    }

    /// <summary>
    /// xダメージを受ける
    /// </summary>
    /// <param name="_x"></param>
    public void Damage(int _x)
    {
        if (m_hpContainer.Count == 0) return;

        m_currentHP -= _x;
        m_currentHP = Mathf.Max(m_currentHP, 0);

        UpdateHP();
    }

    /// <summary>
    /// 死んだか？
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return m_currentHP == 0;
    }

    private void UpdateHP()
    {
        bool[,] result = new bool[4, 3]
        {
            { false, false, false },
            { true, false, false },
            { true, true, false },
            { true, true, true }
        };
        for (int i = 0; i < m_hpContainer.Count; i++)
        {
            m_hpContainer[i].SetActive(result[m_currentHP, i]);
        }
    }
}
