using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Pressing _pressing;

    private float _minChanceSeparation = 0f;
    private float _maxChanceSeparation = 101f;

    private void OnEnable()
    {
        _pressing.cubeClicked += ReviewChance;
    }

    private void OnDisable()
    {
        _pressing.cubeClicked -= ReviewChance;
    }

    private void ReviewChance(Cube cube)
    {
        if(Random.Range(_minChanceSeparation, _maxChanceSeparation) <= cube.GetChanceSeparation())
        {
            _explosion.Explode(_spawner.SpawnCubes(cube), cube);
            _spawner.CubeDestroy(cube);
        }
        else
        {
            _spawner.CubeDestroy(cube);
        }
    }
}
