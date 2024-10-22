using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private TextMeshProUGUI burn;
    [SerializeField] private TextMeshProUGUI paralysis;
    [SerializeField] private TextMeshProUGUI poison;

    public void UpdateHPBar(float currentValue, float MaxValue)
    {
        slider.value = currentValue / MaxValue;
    }

    void Start()
    {
        transform.position = target.position + offset;
        /*RectTransform burnTransform = burn.GetComponent<RectTransform>();
        burnTransform.anchoredPosition = target.position;
        RectTransform paralysisTransform = paralysis.GetComponent<RectTransform>();
        paralysisTransform.anchoredPosition = target.position;
        RectTransform poisonTransform = poison.GetComponent<RectTransform>();
        poisonTransform.anchoredPosition = target.position; */
    }
}
