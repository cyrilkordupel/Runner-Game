using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNARotation : MonoBehaviour
{
    float speedRotation = 90;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        posOffset = transform.position;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime, Space.Self);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = new Vector3(transform.position.x, tempPos.y, transform.position.z);
    }
}
