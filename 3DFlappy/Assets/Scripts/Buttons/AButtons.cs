using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AButtons : MonoBehaviour {

    protected Button[] buttons;

    // Use this for initialization
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    /// <summary>
    ///  ボタン選択
    /// </summary>
    /// <returns>ボタン番号(int)</returns>
    protected abstract int SelectButtons();
}
