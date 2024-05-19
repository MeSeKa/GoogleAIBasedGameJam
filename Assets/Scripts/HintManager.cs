using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager Instance { get; private set; }

    
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        Instance = this;
    }

    public void SetNewHint(string hint)
    {
        textMeshProUGUI.text = hint;
    }

}
