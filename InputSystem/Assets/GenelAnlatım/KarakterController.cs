using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KarakterController : MonoBehaviour
{
    Player player; //Player sýnýfýmýzý eristik
    Vector3 inputDirection;

    bool basildimi; //Buttona verdigimiz press bool ile kontrol ediyoruz
    private void Awake()
    {
        player = new Player();
        //player.PlayerControl.Hareket.started     // Giriþ baþladýmý,herhangi bir etkileþimi kontrol ediyor
        //player.PlayerControl.Hareket.performed   // Etkileþim devam ettikçe
        //player.PlayerControl.Hareket.canceled    // Etkileþim býrakýldýysa ayný Input managerdaki gibi 
        //PlayerControl baðlý olduðu için direkt geldi
        player.PlayerControl.Hareket.performed += x => HareketEt(x.ReadValue<Vector2>());
        //Hareket ettiði müddetçe gelen degeri bu fonksiyona arttýracak
        player.PlayerControl.Hareket.canceled += x => HareketEt(x.ReadValue<Vector2>());


        //    player.PlayerControl.Combo.performed += x => basildimi = x.ReadValueAsButton(); //Bool trueda
        //    player.PlayerControl.Combo.canceled += x => basildimi = x.ReadValueAsButton();  // bool falseda
        // Bu islem sadece bastýðýmýzý algýlamakda falan kullanýyoruz

        player.PlayerControl.Combo.performed += x => BasildimiFonksBasladi();
        player.PlayerControl.Combo.canceled += x => BasildimiFonksBitti();


        /* Hold => Mesela boþluk tuþuna atadýk diyelim basýldýðýnda direkt bitiriyor basýlý tutunca hold sayýyor
         * Multi Tap => Bir kere basarsak basladý yazýyor arka arkaya týklayýnca bitiþi yazýyor arka arka basmamýz lazým
         * Press => Press only --> Press only Basladiyi yazar yani tuþa bastýðýmýzý ilk alýr sonra býrakýldýyý yazar
         * Press => Release only ---> Bitise bakar o yüzden basladi ve bitisi ayný anda yazar
         * Press = > Press and Release ---> Bastýðýmýzda ve býraktýðýmýzda her ikisinde basladi yazar bitis býrakýnca yazar
         * Slow Tap => Multi tpýn tersi -------- Tap => Basýldýðýna bakar
         */


    }
    void HareketEt(Vector2 deger) // OYUN 3D olduðu için Vector 2D degerimi Vector 3D aktarmam lazým
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
            Debug.Log("Basildi"); // Combodaki tuslardan birine bastýðýmýzda basildi yapýyor
        }  */
    }

    private void OnEnable()
    {
        player.PlayerControl.Enable();   //Sýnýf olarak caðýrýrsak sýnýflar arasý geçiþde Enable Disable önemli
    }
    private void OnDisable()
    {
        player.PlayerControl.Disable();
    }
}
