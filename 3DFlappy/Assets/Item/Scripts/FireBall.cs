using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    Vector3 m_power;
    [SerializeField]
    Rect m_clamp;

    //初期化
    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(m_power);
    }

    //更新
    private void Update()
    {
        Clamp();
    }

    private void Clamp()
    {
        Vector2 pos = transform.position;
        ObjectDestroy(transform.gameObject, m_clamp.x > pos.x);
        ObjectDestroy(transform.gameObject, m_clamp.y < pos.y);
        ObjectDestroy(transform.gameObject, m_clamp.width < pos.x);
        ObjectDestroy(transform.gameObject, m_clamp.height > pos.y);
    }

    private void ObjectDestroy(GameObject _obj, bool _flag, float _time = 0f)
    {
        if (!_flag) return;
        Destroy(_obj, _time);
    }
}
