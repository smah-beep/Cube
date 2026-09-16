using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;

    public void Explode(List<Rigidbody> rigidbodyCubes, Cube cube)
    {
        foreach(Rigidbody rigidbodyCube in rigidbodyCubes)
        {
            rigidbodyCube.AddExplosionForce(_explosionForse, cube.gameObject.transform.position, _explosionRadius);
        }              
    }
}
