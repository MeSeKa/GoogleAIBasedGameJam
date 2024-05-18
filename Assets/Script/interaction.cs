using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

interface IIntrectable      // etkileþimli nesnelerde uygulanmasý gereken Interact adýnda bir metot içerir.
{
    public void Interact();

}

public class interaction : MonoBehaviour
{
    public Transform InteractorSource;  //  Etkileþim kaynaðýnýn pozisyonunu ve yönünü belirtir (örneðin, oyuncunun gözleri veya elinin konumu)
    public float InteractRange;   // Etkileþimin gerçekleþebileceði maksimum mesafeyi belirtir.
 
    private void Start()
    {                                                               
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {           
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward); // InteractorSource'un pozisyonundan ileri doðru bir ray (ýþýn) oluþturulur.
            if (Physics.Raycast(r, out RaycastHit hitInfo , InteractRange))    // Physics.Raycast kullanýlarak bu rayýn bir nesneyle çarpýþýp çarpýþmadýðý kontrol edilir.
            {
                if(hitInfo.collider.gameObject.TryGetComponent( out IIntrectable interactobject ) )
                {
                    interactobject.Interact();  // Eðer ray bir nesneyle çarpýþýrsa ve bu nesne IIntrectable arayüzünü uygulayan bir bileþene sahipse, Interact metodu çaðrýlýr.
                }
            }
        }
    }
} 