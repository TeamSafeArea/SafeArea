using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムクラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class Item : MonoBehaviour {
    [SerializeField]
    Vector3 m_power;

	//初期化
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(m_power);
	}
	
	//更新
	void Update () {
		
	}
}
