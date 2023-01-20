using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecor : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    void FixedUpdate()
    {
        transform.position = transform.position + (new Vector3(0,0,-1) * Time.deltaTime * _speed);        
    }
}
