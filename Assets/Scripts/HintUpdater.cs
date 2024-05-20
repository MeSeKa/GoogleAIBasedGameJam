using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HintUpdater : MonoBehaviour
{
    [SerializeField] int hintCount = 0;
    [SerializeField] bool destroyOnTrigger = true;
    [SerializeField] GameObject tutorialObj;

    [SerializeField] Transform returnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string hint = "";
            switch (hintCount)
            {
                case 1:
                    hint = "Neredeyim ben? Bilmediğim bir yerde sıkışıp kaldım. Evime nasıl gideceğim!?\n" + "Time is your Power!!";
                    HintManager.Instance.AddNewControlls("Yön tuşları: W A S D \r\nZıplama: SPACE\r\nKoşma: SHIFT\r\nRestart: R");
                    break;

                case 2:
                    hint = "Kendi zamanıma dönebilmek için buradan kurtulmam lazım." +
                        "Burada bir kapı var ama o kapıya şu an ulaşamam! " +
                        "Tehlikeli görünüyor! Zombiler var." +
                        "Zaman Kapsülünü almalıyım!! (Görmek için Z'ye bas)";
                    HintManager.Instance.AddNewControlls("Kamera: Z X");
                    break;

                case 3:
                    hint = "Zaman yolculuğu çok tehlikeli bir iş. (\"T\" tuşu)\r\nFarklı bir zaman dilimine geçsem bile duvarların içine sıkışmadığımdan emin olsam iyi olacak\r\nNeyseki zamanı başa alabiliyorum (\"R\" tuşu)";
                    HintManager.Instance.AddNewControlls("Zaman Yolculuğu: T");
                    HintManager.Instance.SetCanTimeTravel(true);
                    break;
                case 4:
                    hint = "Aaa! Farklı bir yere ulaştım. Bu inanılmaz!! Peki burada ne yapmalıyım? Yukarıda bir silah var. Evet!! Bu sayede kapının önündeki zombilerden kurtulabilirim!!";
                    break;
                case 5:
                    hint = "Buradan çıkamıyorum. Aaa zamanda geçiş yaparak üst noktaya ulaşabilirim!!";
                    break;
                case 6:
                    hint = "Şimdi korkun benden zombi sürüsü bu zaman silahıyla sizi dirilmeden önceki zamanınıza geri yollayacağım!! Hem kapının önünü temizleyip ilerleyebilirim";
                    HintManager.Instance.AddNewControlls("Ateş Etme: MOUSE CLICK");
                    HintManager.Instance.SetCanAttack(true);
                    break;
                case 7:
                    SceneTransitionManager.Instance.NextLevel();
                    break;


                case 10:
                    hint = "Kendi zamanıma geldim!! Yaşasın!! Ama burası yaşadığım yer değil. Çok yaklaştım burayı geçtikten sonra evime ulaşabileceğim artık!";
                    break;
                case 11:
                    hint = "Kayığa ulaşmam lazım. Onu görebiliyorum ama çok uzaktayım. (Kamera X Y)";
                    break;
                case 12:
                    hint = "Buradan da atlayamam o kadar da değil ölebilirim yani! Sanırım yan taraftan ilerlemem lazım!";
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = false;
                    PlayerSingleton.Instance.transform.position = returnPos.position;
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = true;
                    break;
                case 13:
                    hint = "Bu su çok derin! Karşıya geçmem lazım. Bir dakika!! Artık zaman içerisinde dolanabiliyorum. Burada da bu yeteneğimi kullanmayı mı denesem? (Press T)";
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = false;
                    PlayerSingleton.Instance.transform.position = returnPos.position;
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = true;
                    break;
                case 14:
                    hint = "Evvet, İşe yaradı!! Aynı yerdeyim ama farklı bir zamandayım. Ve ırmak kurumuş! Artık geçebilirim....";
                    break;
                case 15:
                    hint = "(Merdiveni kullanman gerek, Geri Dön!)";
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = false;
                    PlayerSingleton.Instance.transform.position = returnPos.position;
                    PlayerSingleton.Instance.GetComponent<CharacterController>().enabled = true;
                    break;
                case 155:
                    hint = "Aşağı inebildim nihayet şimdi şu kayığa doğru yönelsem iyi olacak";
                    break;
                    
                case 16:
                    hint = "(Çitlerden Kurtul!)";
                    break;
                case 17:
                    hint = "Nihayet Sonunda Başardım!! Artık evime dönebilirim!!";
                    break;
            }

            HintManager.Instance.SetNewHint(hint);

            if (tutorialObj != null)
                tutorialObj.SetActive(false);

            if (destroyOnTrigger)
                this.gameObject.SetActive(false);
        }
    }
}
