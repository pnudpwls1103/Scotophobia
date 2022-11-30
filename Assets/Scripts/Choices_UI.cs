using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Choices_UI : UI_Base
{
    public void OnClickedChoice(int choiceNum)
    {
        Debug.Log($"선택한 번호는 {choiceNum}입니다.");
    }
}
