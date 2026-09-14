using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;
    [SerializeField] private Pressing _pressing;
    [SerializeField] private GameObject _newCubePrefab;

    private float ChanceSeparation = 100f;
    private float _minChanceSeparation = 0f;
    private float _maxChanceSeparation = 101f;
    private int _countCubes;
    private int _minCountNewCube = 2;
    private int _maxCountNewCube = 7;

    private void Update()
    {
        if(_pressing.isClickOnCub == true)
        {
            Destroy(gameObject);

            if(Random.Range(_minChanceSeparation, _maxChanceSeparation) <= ChanceSeparation)
            {
                SpawnCubes();
            }           
        }
    }

    private void SpawnCubes()
    {
        _countCubes = Random.Range(_minCountNewCube, _maxCountNewCube);

        for (int i = 0; i < _countCubes; i++)
        {
            GameObject newCube = Instantiate(_newCubePrefab, transform.position, transform.rotation);
            Renderer newCubeRenderer = newCube.GetComponent<Renderer>();
            Explosion explosionNewCube = newCube.GetComponent<Explosion>();
            Rigidbody newCubeRigidbody = newCube.GetComponent<Rigidbody>();
            explosionNewCube.enabled = true;

            newCube.transform.localScale = transform.localScale / 2;
            newCubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            explosionNewCube.ChanceSeparation /= 2;
            newCubeRigidbody.AddExplosionForce(_explosionForse, newCube.transform.position, _explosionRadius);
        }
    }
}
