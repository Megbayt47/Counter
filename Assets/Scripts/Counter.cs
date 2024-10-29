using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _count = 0;

    private Coroutine _counterCoroutine;
    private WaitForSeconds _wait;

    private void Start()
    {
        _text.text = "0";
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
            _text.text = _count.ToString();

            yield return _wait;
        }
    }
}