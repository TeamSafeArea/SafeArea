using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [SerializeField]
    private float m_MoveSpeed;

	// Use this for initialization
	void Start () {
        GameObject.Find("Laser").GetComponent<EnemyLaser>().Initialize();
	}

    void Update()
    {
        
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-m_MoveSpeed, 0, 0);
    }
}
