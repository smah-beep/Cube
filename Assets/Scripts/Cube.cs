using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceSeparation = 100f;
    private Renderer _renderer;

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
        transform.localScale /= 2f;
    }
}
