using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KarakterControlleriki : MonoBehaviour
{
    Player player;
    Vector3 inputDirection;

    private void Awake()
    {
        player = new Player();
    }


    //SendMessage ile yapýlýrsa böyle eðer Invoke ile yapýlcaksa aþaðýdaki gibi
    /*
    public void OnHareket(InputValue value) 
    {
        Vector2 gelenVector = value.Get<Vector2>(); 
        inputDirection = new Vector3(gelenVector.x,0,gelenVector.y);
    }

    public void OnCombo(InputValue value)
    {
        if (value.isPressed)
            Debug.Log("Basýlmasýný yakaladýk");
    }
    */


    // Invoke Unity Elements ile yapýlacaksa böyle yapýlýr isimler özelleþtirilebilir
    public void HareketInvoke(InputAction.CallbackContext value)
    {
        Vector2 gelenVector = value.ReadValue<Vector2>();
        inputDirection = new Vector3(gelenVector.x,0,gelenVector.y);
    }
    public void ComboInvoke(InputAction.CallbackContext value)
    {
        if (value.started)
            Debug.Log("Basýlmasýný yakaladýk");
    }



    private void Update()
    {
        transform.Translate(inputDirection * Time.deltaTime * 10f);
    }
}
