using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private ShadowFiendMove _shadowFiendMove;

    private void Awake()
    {
        _shadowFiendMove.HealthChanged += OnHealthChanged;
    }
    
    private void OnHealthChanged(float value)
    {
        Debug.Log(value);

        _healthBarFilling.fillAmount = value;
    }
}
