using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

interface IIntrectable      // etkile�imli nesnelerde uygulanmas� gereken Interact ad�nda bir metot i�erir.
{
    public void Interact();

}

public class interaction : MonoBehaviour
{
    public Transform InteractorSource;  //  Etkile�im kayna��n�n pozisyonunu ve y�n�n� belirtir (�rne�in, oyuncunun g�zleri veya elinin konumu)
    public float InteractRange;   // Etkile�imin ger�ekle�ebilece�i maksimum mesafeyi belirtir.
 
    private void Start()
    {                                                               
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {           
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward); // InteractorSource'un pozisyonundan ileri do�ru bir ray (���n) olu�turulur.
            if (Physics.Raycast(r, out RaycastHit hitInfo , InteractRange))    // Physics.Raycast kullan�larak bu ray�n bir nesneyle �arp���p �arp��mad��� kontrol edilir.
            {
                if(hitInfo.collider.gameObject.TryGetComponent( out IIntrectable interactobject ) )
                {
                    interactobject.Interact();  // E�er ray bir nesneyle �arp���rsa ve bu nesne IIntrectable aray�z�n� uygulayan bir bile�ene sahipse, Interact metodu �a�r�l�r.
                }
            }
        }
    }
} 