﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  レーザー発射関係の処理
///  Written by 佐野直樹
/// </summary>
public class EnemyLaser : MonoBehaviour {

    [SerializeField]
    private GameObject m_LaserEffect;
    [SerializeField]
    private SpriteRenderer m_AttentionSprite;

    Color m_SpriteColor;    // アルファ値の保存先
    bool m_AlphaUpDown;     // アルファ値の上下のフラグ
    bool m_ActiveSprite;    // アクティブ化

	// Use this for initialization
	void Start () {
        
        m_AttentionSprite = m_AttentionSprite.GetComponent<SpriteRenderer>();
        m_SpriteColor = m_AttentionSprite.color;
        m_SpriteColor.a = 0.01f;
        m_AttentionSprite.color = m_SpriteColor;

        m_ActiveSprite = false;
	}
	
	// Update is called once per frame
	void Update () {
        SpriteAlpha();
	}


    /// <summary>
    ///  スプライトを表示非表示
    /// </summary>
    void SpriteAlpha()
    {
        // レーザーが非アクティブなら終了
        if (!m_ActiveSprite) return;


        // Laser予告スプライトのアルファ値をとる
        m_SpriteColor = m_AttentionSprite.color;

        /* アルファ値の操作フラグ */
        if (m_SpriteColor.a >= 1) m_AlphaUpDown = true;
        else if (m_SpriteColor.a <= 0) m_AlphaUpDown = false;


        if(!m_AlphaUpDown)
        {   
            // まずは透明度を下げて出現させる
            m_SpriteColor.a += 0.3f;
        }
        else
        {
            // 出現させたら逆に消していく
            m_SpriteColor.a -= 0.02f;
        }

        // 消滅しきったら
        if (m_SpriteColor.a <= 0)
        {
            // レーザー本体をアクティブ化
            m_LaserEffect.SetActive(true);

            // スプライトは停止
            m_ActiveSprite = false;
            return;
        }

        // 上で操作したアルファ値の適用
        m_AttentionSprite.color = m_SpriteColor;
    }

    /// <summary>
    ///  ここで初期化、これを呼ぶと発射開始
    /// </summary>
    public void Initialize()
    {
        m_SpriteColor.a = 0.01f;
        m_SpriteColor.g = 1;
        m_AttentionSprite.color = m_SpriteColor;

        m_ActiveSprite = true;
    }
}
