using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ExplosionRadius { get; private set; } = 20;
    public float ExplosionForse { get; private set; } = 280;
    private float _coefficientIncrease = 1.5f;

    private float _chanceSeparation = 100f;   
    private float _coefficientÂecrease = 2f;
    private Renderer _renderer;

    public float GetChanceSeparation() => _chanceSeparation;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void Shrink()
    {
        transform.localScale /= _coefficientÂecrease;
    }

    public void GetReduceChanceSeparation()
    {
        _chanceSeparation /= _coefficientÂecrease;
    }

    public void IncreasePowerExplosion()
    {
        ExplosionForse *= _coefficientIncrease;
        ExplosionRadius *= _coefficientIncrease;
    }
}
