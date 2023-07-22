using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingScene : MonoBehaviour
{
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject Dot1;
    [SerializeField] GameObject Dot2;
    bool _turnedOff = true;
    private void Start()
    {
        StartCoroutine(WaitingDot1());
        StartCoroutine(WaitingDot2());
        StartCoroutine(WaitingDot3());
    }

    void FixedUpdate()
    {
        Arrow.transform.DORotate(new Vector3(0, 0,360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }


    IEnumerator WaitingDot1() 
    {
        while (true)
        {
            Dot1.SetActive(true);
            _turnedOff=false;
            yield return new WaitForSeconds(5);
        }
    }
    IEnumerator WaitingDot2() 
    {
        while (true)
        {
            Dot2.SetActive(true);
            _turnedOff = false;
            yield return new WaitForSeconds(7);
        }
    } 
    IEnumerator WaitingDot3() 
    {
        while (true)
        {
            Dot1.SetActive(false);
            Dot2.SetActive(false);
            _turnedOff = true;
            yield return new WaitForSeconds(10);
        }
    }
}
