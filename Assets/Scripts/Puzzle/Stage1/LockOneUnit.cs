using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockOneUnit : UI_Base
{
    public int CurrentNum { get { return currentNum; } }
    int currentNum = 0;
    enum Texts
    {
        Number,
    }

    enum Buttons
    {
        UpButton,
        DownButton,
    }
    void Start()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Button btn = dic[typeof(Buttons)][(int)Buttons.UpButton] as Button;
        btn.onClick.AddListener(OnClickUpBtn);
        btn = dic[typeof(Buttons)][(int)Buttons.DownButton] as Button;
        btn.onClick.AddListener(OnClickDownBtn);
    }

    void OnClickUpBtn()
    {
        currentNum = (currentNum + 1) % 10;
        UpdateText();
    }

    void OnClickDownBtn()
    {
        currentNum = (currentNum + 9) % 10;
        UpdateText();
    }

    void UpdateText()
    {
        TextMeshProUGUI text = dic[typeof(Texts)][(int)Texts.Number] as TextMeshProUGUI;
        text.text = currentNum.ToString();
    }
}
