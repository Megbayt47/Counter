using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _count = 0;

    public Coroutine IncreaseCounterCoroutine;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IncreaseCounterCoroutine == null)
            {
                IncreaseCounterCoroutine = StartCoroutine(IncreaseCounter());
            }
            else
            {
                StopCoroutine(IncreaseCounterCoroutine);
                IncreaseCounterCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (_count >= 0)
        {
            _count++;
            _text.text = _count.ToString();

            yield return new WaitForSeconds(_delay);
        }
    }
}