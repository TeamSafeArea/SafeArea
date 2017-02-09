using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  無効化する処理
/// </summary>
public class SetActiveSelf : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {
        timer = 6;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 2 * Time.deltaTime;

        if (timer <= 0) this.gameObject.SetActive(false);
	}
}
