using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _newPos;

    private void Update()
    {
        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.x += Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(newRot);
    }
}
