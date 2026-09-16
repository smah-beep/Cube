using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressing : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit hit;

    public event Action<Cube> cubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit))
            {
                Cube cube = hit.collider.gameObject.GetComponent<Cube>();

                if (cube != null)
                {
                    cubeClicked?.Invoke(cube);
                }
            }
        }
    }
}