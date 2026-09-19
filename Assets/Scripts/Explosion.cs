using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.gameObject.transform.position, _explosionRadius);

        List<Rigidbody> rigidbodyCubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                rigidbodyCubes.Add(hit.attachedRigidbody);
            }
        }

        return rigidbodyCubes;
    }

    public void Explode(List<Rigidbody> rigidbodyCubes, Cube cube)
    {
        foreach(Rigidbody rigidbodyCube in rigidbodyCubes)
        {
            rigidbodyCube.AddExplosionForce(_explosionForse, cube.gameObject.transform.position, _explosionRadius);
        }              
    }

    public void Explode(Cube cube)
    {
        foreach(Rigidbody explodableObject in GetExplodableObjects(cube))
        {
            explodableObject.AddExplosionForce(cube.ExplosionForse, cube.gameObject.transform.position, cube.ExplosionRadius);
        }
    }
}
