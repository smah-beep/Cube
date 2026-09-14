using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressing : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public bool isClickOnCub { get; private set; } = false;

    private Ray _ray;
    private RaycastHit hit;

    private void OnMouseUpAsButton()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out hit))
        {
            if(hit.transform.tag == "Cub")
            {
                isClickOnCub = true;
            }           
        }
    }
}
