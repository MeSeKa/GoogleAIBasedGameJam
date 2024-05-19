using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintUpdater : MonoBehaviour
{
    [SerializeField] int hintCount = 0;

    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string hint = "";
            switch (hintCount)
            {
                case 1:
                    hint = "Neredeyim ben? Bilmediğim bir yerde sıkışıp kaldım. Evime nasıl gideceğim!?";
                    break;


            }

            HintManager.Instance.SetNewHint(hint);

        }
    }
}
