using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _newCubePrefab;

    private int _countCubes;
    private int _minCountNewCube = 2;
    private int _maxCountNewCube = 7;

    public List<Rigidbody> SpawnCubes(Cube parentCube)
    {
        List<Rigidbody> rigidbodyCubes = new List<Rigidbody>();

        _countCubes = Random.Range(_minCountNewCube, _maxCountNewCube);

        for (int i = 0; i < _countCubes; i++)
        {            
            GameObject newCube = Instantiate(parentCube.gameObject, parentCube.gameObject.transform.position, transform.rotation);

            Cube cube = newCube.GetComponent<Cube>();
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

            cube.Shrink();               
            cube.SetRandomColor();
            cube.GetReduceChanceSeparation();
            cube.IncreasePowerExplosion();

            rigidbodyCubes.Add(cubeRigidbody);
        }
        return rigidbodyCubes;
    }

    public void CubeDestroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
