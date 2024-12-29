using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// テキストの表示を担当するインターフェース
/// 作成 : 2024/12/29
/// yoshikawa
/// </summary>
public interface ITextShower
{
    public void ShowText(bool isActive,string text = "");
}


/// <summary>
/// 一番ベーシックなテキストの表示を担当する実装。
/// （テキストを表示させるときは基本的にこれを使えばOK）
/// 作成 : 2024/12/29
/// yoshikawa
/// </summary>
public class TextShower : MonoBehaviour,ITextShower
{
    TextMeshProUGUI _text;
    public void ShowText(bool isActive, string text = "")
    {
        if (isActive)
        {
            _text.gameObject.SetActive(true);
            _text.text = text;
        }
        else
        {
            _text.gameObject.SetActive(false);
        }
    }
}
