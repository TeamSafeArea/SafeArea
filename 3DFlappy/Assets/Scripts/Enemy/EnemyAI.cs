using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Enemyの思考パターン
///  Written by 佐野直樹
/// </summary>
public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private EnemyBarrel m_Barrel;   // バレル攻撃
    [SerializeField]
    private EnemyLaser m_Laser;     // レーザー攻撃
    [SerializeField]
    private int m_MinTime, m_MaxTime;   // インターバルのランダム値

    private float m_time;           // 蓄積タイム
    private int m_interval;         // インターバルタイム

	// Use this for initialization
	void Start () {
        m_Laser = m_Laser.GetComponent<EnemyLaser>();
        m_interval = Random.Range(m_MinTime, m_MaxTime + 1); // インターバル決定
    }
	
	// Update is called once per frame
	void Update () {
        AttackPattern(Timer());

        //Debug.Log(m_interval);
	}

    /// <summary>
    ///  タイマー
    /// </summary>
    bool Timer()
    {
        m_time += 2 * Time.deltaTime;           // タイム++

        if (m_interval >= m_time) return false;  // インターバル以下ならfalse

        m_interval = Random.Range(m_MinTime, m_MaxTime + 1); // インターバル決定
        m_time = 0;

        return true;    // 以上ならtrue
    }

    void AttackPattern(bool _isAttack)
    {
        // 攻撃フラグが立っていなかったら攻撃しない
        if (!_isAttack) return;



        /* 攻撃パターン決定 */
        int _attackPattern = Random.Range(0, 100);
        if(_attackPattern <= 19)
        {

        }
        else
        {

        }

    }

}
