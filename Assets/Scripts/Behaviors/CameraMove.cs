using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Controller controller;
    [SerializeField] private GameObject camOrigin;
    private Vector2 camLunge;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
        controller.OnLookEvent += SetLunge;
    }

    private void SetLunge(Vector2 vector)
    {
        if (vector.magnitude > 3.0f)
            camLunge = vector.normalized * Mathf.Min(5.0f, vector.magnitude - 3.0f);
        else
            camLunge = Vector2.zero;
    }

    public void SetOrigin(GameObject _origin)
    {
        camOrigin = _origin;
    }

    public void Update()
    {
        if (camOrigin != null)
        {
            transform.position = camOrigin.transform.position + (Vector3)camLunge + new Vector3(0, 0, -10);
        }
    }
}
