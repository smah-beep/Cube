using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Pressing _pressing;

    private float _minChanceSeparation = 0f;
    private float _maxChanceSeparation = 100f;

    private void OnEnable()
    {
        _pressing.ÑubeClicked += ReviewChance;
    }

    private void OnDisable()
    {
        _pressing.ÑubeClicked -= ReviewChance;
    }

    private void ReviewChance(Cube cube)
    {
        if(Random.Range(_minChanceSeparation, _maxChanceSeparation + 1) <= cube.GetChanceSeparation())
        {
            _explosion.Explode(_spawner.SpawnCubes(cube), cube);
            _spawner.CubeDestroy(cube);
        }
        else
        {
            _explosion.Explode(cube);
            _spawner.CubeDestroy(cube);
        }
    }
}
