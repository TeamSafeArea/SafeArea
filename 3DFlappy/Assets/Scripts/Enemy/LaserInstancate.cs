using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInstancate : MonoBehaviour {

    [SerializeField]
    GameObject m_Laser;

	// Use this for initialization
    public void ShotLaser()
    {
        Instantiate(m_Laser, transform.position, this.gameObject.transform.rotation);
    }
}
