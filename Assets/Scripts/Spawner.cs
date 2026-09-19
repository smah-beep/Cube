using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _countCubes;
    private int _minCountNewCube = 2;
    private int _maxCountNewCube = 6;

    public List<Rigidbody> SpawnCubes(Cube parentCube)
    {
        List<Rigidbody> rigidbodyCubes = new List<Rigidbody>();

        _countCubes = Random.Range(_minCountNewCube, _maxCountNewCube + 1);

        for (int i = 0; i < _countCubes; i++)
        {            
            Cube newCube = Instantiate(parentCube, parentCube.gameObject.transform.position, transform.rotation);

            Rigidbody cubeRigidbody = newCube.Rigidbody;

            newCube.Init();
            rigidbodyCubes.Add(cubeRigidbody);
        }
        return rigidbodyCubes;
    }

    public void CubeDestroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
