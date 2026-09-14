using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;
    [SerializeField] private Pressing _pressing;

    private float _minChanceSeparation = 0f;
    private float _maxChanceSeparation = 101f;

    private void Update()
    {
        GameObject clickedCube = _pressing.ClickedCub;

        if(clickedCube != null)
        {
            Explode(clickedCube.GetComponent<Rigidbody>());
            Destroy(clickedCube);
        }
    }

    private void Explode(Rigidbody _explodableObjects)
    {
        _explodableObjects.AddExplosionForce(_explosionForse, _explodableObjects.position, _explosionRadius);

        if (Random.Range(_minChanceSeparation, _maxChanceSeparation) <= _explodableObjects.GetComponent<Cube>().ChanceSeparation)
        {
            _explodableObjects.GetComponent<Spawner>().SpawnCubes();
        }
    }
}
