using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  EnemyがPlayerに向かってBarrel発射
///  Written by 佐野直樹
/// </summary>
public class EnemyBarrel : MonoBehaviour {

    [SerializeField]
    private GameObject m_Barrel;
	
    /// <summary>
    ///  Barrel弾を撃つ
    /// </summary>
    void ShotBarrel()
    {
        Instantiate(m_Barrel, transform.position, this.gameObject.transform.rotation);
    }
}
