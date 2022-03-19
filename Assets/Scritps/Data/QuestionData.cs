using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    /// <summary>
    /// 질문
    /// </summary>
    public string que;
    /// <summary>
    /// 정답
    /// </summary>
    public string corAns;

    /// <summary>
    /// 오답들
    /// </summary>
    public List<string> incorAns;
}
