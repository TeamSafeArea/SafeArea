using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Item
{
    [SerializeField]
    Vector3 m_power;

    //オブジェクト初期化
    protected override void ObjectStart()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(m_power);
    }

    //オブジェクト更新
    protected override void ObjectUpdate()
    {

    }
}
