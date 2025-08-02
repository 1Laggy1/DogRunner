using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5F;

    public GameObject player;
    public float x = -6;
    public double y = 0.5;

    [SerializeField]
    private Transform pl
;

    private void Awake()
    {
        pl = player.transform;
    }

    private void Update()
    {
        Vector3 position = pl.position;        position.z = -10.0F;

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }

    public void Restart()
    {

        transform.position = new Vector2((float)x, (float)y);
    }
}
