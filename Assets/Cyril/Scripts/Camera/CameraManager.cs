using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _PointBase;
    [SerializeField] private Transform _PointDown;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private bool _lerpBool = true;
    private bool _once = true;
    private bool _onceV2 = true;
    private void Update() 
    {
        if(_lerpBool && _once)  StartCoroutine(LerpCamera(_PointBase.position,_PointDown.position));
        if(_lerpBool == false && _onceV2) StartCoroutine(LerpCam(_PointDown.position,_PointBase.position));
    }
    public IEnumerator LerpCamera(Vector3 Base , Vector3 Down)
    {
        float elapsedTime = 0f;
        _once = false;
        while(elapsedTime < _lerpSpeed && _lerpBool)
        {
            transform.position = Vector3.Lerp(Base,Down, elapsedTime / _lerpSpeed);
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime + "TimeS");
            yield return null;
        }
        _onceV2 = true;
        yield return new WaitForSeconds(1);
    }
    public IEnumerator LerpCam(Vector3 Base , Vector3 Down)
    {
        float elapsedTime = 0f;
        _onceV2 = false;
        while(elapsedTime < _lerpSpeed)
        {
            transform.position = Vector3.Lerp(Base,Down, elapsedTime / _lerpSpeed);
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime + "Time");
            yield return null;
        }
        _once = true;
    }
}