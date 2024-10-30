using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private Coroutine _counterCoroutine;
    private WaitForSeconds _wait;
    private int _count;
    private float _delay = 0.5f;

    public event Action<int> CountChanged;

    private void Start()
    {
        _count = 0;
        CountChanged?.Invoke(_count);
        _wait = new WaitForSeconds(_delay);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counterCoroutine == null)
            {
                _counterCoroutine = StartCoroutine(CountUp());
            }
            else
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator CountUp()
    {
        while (_count >= 0)
        {
            _count++;
            CountChanged?.Invoke(_count);
            yield return _wait;
        }
    }
}