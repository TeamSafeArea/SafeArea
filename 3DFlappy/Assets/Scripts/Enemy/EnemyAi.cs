using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  敵クラス
///  by 佐野直樹
/// </summary>
public class EnemyAI : MonoBehaviour {

    [SerializeField]
    EnemyBarrel m_Barrel;   // バレル
    [SerializeField]
    EnemyLaser m_Laser;     // レーザー
    [SerializeField]
    int m_MinInterval, m_MaxInterval;   // インターバルタイム値の最大と最小
    [SerializeField]
    HP_UI m_HP;             // HP
    [SerializeField]
    Player m_Player;        // プレイヤー取得

    Timer m_Timer;  // タイマー
    [SerializeField]
    EndingSprites m_Ending;


    // Use this for initialization
    void Start () {
        m_Player = m_Player.GetComponent<Player>();

        /* タイマーの初期化 */
        m_Timer = new Timer();
        m_Timer.SetTime(SetIntervalByRandom());
        m_Timer.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_HP.Damage(1);
        }

        // ダメージ
        Damage();

        // タイマー更新
        Timer();

        // 死んだか
        IsDead();
	}

    /// <summary>
    ///  インターバル時間をランダムに設定
    /// </summary>
    /// <returns></returns>
    float SetIntervalByRandom()
    {
        float random = Random.Range(m_MinInterval, m_MaxInterval + 1);
        return random;
    }

    /// <summary>
    ///  攻撃がヒットしたかを取得
    /// </summary>
    /// <returns></returns>
    bool HitDamage()
    {
        return m_Player.IsAttack();
    }

    /// <summary>
    ///  ダメージ
    /// </summary>
    void Damage()
    {
        if (HitDamage()) m_HP.Damage(1);
    }

    void Timer()
    {
        m_Timer.Update();

        // タイマーが終了していなければ攻撃しない
        if (!m_Timer.IsEnd()) return;

        /* HPが2以上ならバレル攻撃だけ */
        if(m_HP.GetHp() >= 2)
        {
            ShotBarrel();
            TimerReset();
            return;
        }

        /* HPが1以下ならバレルかレーザー */
        // 攻撃割合設定のための乱数決定
        int attackPattern = Random.Range(1, 101);

        /* ２割の確率でレーザー発射、それ以外はバレル */
        if (attackPattern >= 21) ShotBarrel();
        else ShotLaser();

        TimerReset();

    }

    /// <summary>
    ///  タイマーリセット
    /// </summary>
    void TimerReset()
    {
        m_Timer.SetTime(SetIntervalByRandom());
        m_Timer.Reset();
        m_Timer.Start();
    }

    /// <summary>
    ///  バレル発射
    /// </summary>
    void ShotBarrel()
    {
        m_Barrel.ShotBarrel();
    }

    /// <summary>
    ///  レーザー発射
    /// </summary>
    void ShotLaser()
    {
        m_Laser.Initialize();
    }

    private void IsDead()
    {
        if (m_HP.IsDead())
            m_Ending.SetEndingBeginFlag(true, false);
    }
}
