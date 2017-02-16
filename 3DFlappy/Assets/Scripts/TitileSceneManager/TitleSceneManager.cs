using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルマネージャー
/// Yuuho Aritomi
/// 2017/02/16
/// </summary>
public class TitleSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayBGM("Title");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
