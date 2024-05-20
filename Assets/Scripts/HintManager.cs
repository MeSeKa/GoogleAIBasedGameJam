using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [SerializeField] bool canAttack = false;
    [SerializeField] bool canTimeTravel = false;
    public static HintManager Instance { get; private set; }

    [SerializeField] TypingEffect typingEffect;


    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] TextMeshProUGUI controls;

    public bool CanAttack { get; private set; }
    public bool CanTimeTravel { get; private set; }

    private void Awake()
    {
        Instance = this;
        CanAttack = canAttack;
        CanTimeTravel = canTimeTravel;
    }

    public void SetNewHint(string hint)
    {
        typingEffect.StartTypingAnimation(hint);
    }

    public void AddNewControlls(string text)
    {
        controls.text += "\n" + text;
    }

    public void SetCanAttack(bool set)
    {
        CanAttack = set;
    }

    public void SetCanTimeTravel(bool set)
    {
        CanTimeTravel= set;
    }
}
