
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    [SerializeField]
    Vector3 m_power;

    //初期化
    private void Start() {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(m_power);
    }

    //更新
    private void Update() {

    }
}
