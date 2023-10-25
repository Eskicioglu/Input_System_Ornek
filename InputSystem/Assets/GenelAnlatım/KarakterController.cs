using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KarakterController : MonoBehaviour
{
    Player player; //Player s�n�f�m�z� eristik
    Vector3 inputDirection;

    bool basildimi; //Buttona verdigimiz press bool ile kontrol ediyoruz
    private void Awake()
    {
        player = new Player();
        //player.PlayerControl.Hareket.started     // Giri� ba�lad�m�,herhangi bir etkile�imi kontrol ediyor
        //player.PlayerControl.Hareket.performed   // Etkile�im devam ettik�e
        //player.PlayerControl.Hareket.canceled    // Etkile�im b�rak�ld�ysa ayn� Input managerdaki gibi 
        //PlayerControl ba�l� oldu�u i�in direkt geldi
        player.PlayerControl.Hareket.performed += x => HareketEt(x.ReadValue<Vector2>());
        //Hareket etti�i m�ddet�e gelen degeri bu fonksiyona artt�racak
        player.PlayerControl.Hareket.canceled += x => HareketEt(x.ReadValue<Vector2>());


        //    player.PlayerControl.Combo.performed += x => basildimi = x.ReadValueAsButton(); //Bool trueda
        //    player.PlayerControl.Combo.canceled += x => basildimi = x.ReadValueAsButton();  // bool falseda
        // Bu islem sadece bast���m�z� alg�lamakda falan kullan�yoruz

        player.PlayerControl.Combo.performed += x => BasildimiFonksBasladi();
        player.PlayerControl.Combo.canceled += x => BasildimiFonksBitti();


        /* Hold => Mesela bo�luk tu�una atad�k diyelim bas�ld���nda direkt bitiriyor bas�l� tutunca hold say�yor
         * Multi Tap => Bir kere basarsak baslad� yaz�yor arka arkaya t�klay�nca biti�i yaz�yor arka arka basmam�z laz�m
         * Press => Press only --> Press only Basladiyi yazar yani tu�a bast���m�z� ilk al�r sonra b�rak�ld�y� yazar
         * Press => Release only ---> Bitise bakar o y�zden basladi ve bitisi ayn� anda yazar
         * Press = > Press and Release ---> Bast���m�zda ve b�rakt���m�zda her ikisinde basladi yazar bitis b�rak�nca yazar
         * Slow Tap => Multi tp�n tersi -------- Tap => Bas�ld���na bakar
         */


    }
    void HareketEt(Vector2 deger) // OYUN 3D oldu�u i�in Vector 2D degerimi Vector 3D aktarmam laz�m
    {
        inputDirection = new Vector3(deger.x,0,deger.y);
    }

    void BasildimiFonksBasladi()
    {
        Debug.Log("Basladi");
        Debug.Log(player.PlayerControl.Combo.name  +"Basildi"); // Hangi tusa basildigi
        Debug.Log(player.PlayerControl.Combo.activeControl + "Basilantus"); // Basilan tusu verir bize                                                   //
        Debug.Log(player.PlayerControl.Combo.bindings + "Basiliyor");
    }

    void BasildimiFonksBitti()
    {
        Debug.Log("Bitti");
    }



    private void Update()
    {
        transform.Translate(inputDirection*Time.deltaTime*10f);

      /*  if (basildimi)
        {
            Debug.Log("Basildi"); // Combodaki tuslardan birine bast���m�zda basildi yap�yor
        }  */
    }

    private void OnEnable()
    {
        player.PlayerControl.Enable();   //S�n�f olarak ca��r�rsak s�n�flar aras� ge�i�de Enable Disable �nemli
    }
    private void OnDisable()
    {
        player.PlayerControl.Disable();
    }
}
