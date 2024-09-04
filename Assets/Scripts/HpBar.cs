using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateHPBar(float currentValue, float MaxValue)
    {
        slider.value = currentValue / MaxValue;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; 
    }
}
