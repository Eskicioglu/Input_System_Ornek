using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenemeSc : MonoBehaviour
{
    [SerializeField] Vector3 _direction;
    [SerializeField] float factor;
    [SerializeField] float speed=1f;

    private const float Full_Circle = Mathf.PI * 2;

    Vector3 _startPos;

    private void Awake()
    {
        
        _startPos = transform.position;
    }

    private void Update()
    {
        float cycsle = Time.time / speed;
        float sinWay = Mathf.Sin(Full_Circle * cycsle);

        factor = Mathf.Abs(sinWay);

        Vector3 offset = _direction * factor;
        transform.position = _startPos + offset;
    }
}
