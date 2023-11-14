using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem.DogruKodlama;


namespace InputSystem.DogruKodlama
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _force;


        Rigidbody _rb;
        DefaultInput _input;

        bool _isForceUp; //Burasý bir güç uyguluyor deðilmi eðer bu güç varsa true falsa bakacaz

        private void Awake()
        {
             _rb = GetComponent<Rigidbody>();
             _input = new DefaultInput();
        }

        private void Update()
        {
            if (_input.IsForceUp) //Eðer bu güç varsa true
            { 
               _isForceUp=true;
            }
            else             
            {
                _isForceUp = false;
            }
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _rb.AddForce(Vector3.up*Time.deltaTime*_force);
            }
        }

    }
}
