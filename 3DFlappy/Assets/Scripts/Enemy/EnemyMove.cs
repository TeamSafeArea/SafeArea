using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  EnemyがPlayerに向かって移動
///  Written by 佐野直樹
/// </summary>
public class EnemyMove : MonoBehaviour {

    [SerializeField]
    private float m_MoveSpeed;
	
	// Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-m_MoveSpeed, 0, 0);
    }
}
