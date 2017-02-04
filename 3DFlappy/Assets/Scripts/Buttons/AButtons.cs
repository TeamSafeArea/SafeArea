using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class AButtons : MonoBehaviour {

    [SerializeField]
    private Button[] buttons; // ボタンの配列
    private int buttonsCount; // ボタンの個数を取る
    private int nowButton;   // 選択ボタン

    // Use this for initialization
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    /// <summary>
    ///  ボタン選択
    /// </summary>
    /// <returns>ボタン番号(int)</returns>
    protected abstract int SelectButtons();

    // ボタンをハイライト
    protected abstract void HighLightButtons(int now);
}
