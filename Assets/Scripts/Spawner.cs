using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _newCubePrefab;

    private int _countCubes;
    private int _minCountNewCube = 2;
    private int _maxCountNewCube = 7;

    public void SpawnCubes()
    {
        _countCubes = Random.Range(_minCountNewCube, _maxCountNewCube);

        for (int i = 0; i < _countCubes; i++)
        {
            GameObject newCube = Instantiate(_newCubePrefab, transform.position, transform.rotation);

            Cube cube = newCube.GetComponent<Cube>();

            cube.Shrink();               
            cube.SetRandomColor();          
            cube.ChanceSeparation /= 2f;
        }            
    }
}
