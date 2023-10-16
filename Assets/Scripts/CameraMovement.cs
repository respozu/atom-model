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
        newRot.y += Input.GetAxis("Mouse X");
        newRot.x += -Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(newRot);

        if (Input.GetKey(KeyCode.W))
        {
            _newPos.x += 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _newPos.x -= 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _newPos.z += 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _newPos.z -= 1f * Time.deltaTime;
        }

        transform.localPosition += _newPos;
        _newPos = Vector3.zero;
    }
}
