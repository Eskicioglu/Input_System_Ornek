using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KarakterKontrol_1 : MonoBehaviour
{
    Vector3 inputdirection;
    Vector2 Rotasyon;
    public GameObject mermi;
    public GameObject FirePoint;
    private void Start()
    {
        if (Accelerometer.current !=null)
        {
          //   InputSystem.EnableDevice(Accelerometer.current);

        }
    }


    public void OnHareket(InputValue value)
    {
        Vector2 gelenvector = Accelerometer.current.acceleration.ReadValue();
       

        inputdirection = new Vector3(gelenvector.x, 0, gelenvector.y);
    }

    public void OnNavigate(InputValue value)
    {
        Vector2 gelenvector = value.Get<Vector2>();


        inputdirection = new Vector3(gelenvector.x, 0, gelenvector.y);
    }

    public void OnZiplama(InputValue value)
    {
        
        if (value.Get()!=null)
        {
            GetComponent<Rigidbody>().AddForce(0, 10, 2f, ForceMode.Impulse);
        }
    }
    public void OnAtesEtme(InputValue value)
    {

        if (value.Get() != null)
        {
            GameObject OlusanMermi = Instantiate(mermi, FirePoint.transform.position, FirePoint.transform.rotation);
            OlusanMermi.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);
        }
    }
    public void OnDonus(InputValue value)
    {

        Rotasyon = value.Get<Vector2>();
    }


    void Update()
    {
        transform.Translate(inputdirection * Time.deltaTime * 20f);

        Vector2 r = new Vector2(0, Rotasyon.x) * 250f * Time.deltaTime;
        transform.Rotate(r,Space.World);

    }
}
