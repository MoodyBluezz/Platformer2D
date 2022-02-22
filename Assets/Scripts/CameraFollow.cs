using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        _camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, _camera.transform.position.z);
    }
}
