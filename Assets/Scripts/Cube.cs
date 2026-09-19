using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ExplosionRadius { get; private set; } = 20;
    public float ExplosionForse { get; private set; } = 280;
    public Rigidbody Rigidbody { get; private set; }

    private float _coefficientIncrease = 1.5f;
    private float _chanceSeparation = 100f;   
    private float _coefficientÂecrease = 2f;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
        transform.localScale /= _coefficientÂecrease;
        _chanceSeparation /= _coefficientÂecrease;
        ExplosionForse *= _coefficientIncrease;
        ExplosionRadius *= _coefficientIncrease;
    }

    public float GetChanceSeparation() => _chanceSeparation;
}
