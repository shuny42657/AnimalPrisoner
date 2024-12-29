using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

/// <summary>
/// テキストが表示される際にどのようなアニメーションと共に
/// 表示するかを定めるインタフェース
/// 作成:2024/12/29
/// yoshikawa
/// </summary>
public interface ITextAnimation
{
    public UniTask ShowTextAnimation(string text);
}

/// <summary>
/// 表示後、一定時間後に表示が消える処理
/// </summary>
public class FixedTextAnimation : ITextAnimation
{
    ITextShower _textShower;
    float _duration;

    public FixedTextAnimation(ITextShower textShower,float duration)
    {
        _textShower = textShower;
        _duration = duration;
    }

    public async UniTask ShowTextAnimation(string text)
    {
        _textShower.ShowText(true, text);
        await UniTask.Delay(TimeSpan.FromSeconds(_duration));
        _textShower.ShowText(false);
    }
}
