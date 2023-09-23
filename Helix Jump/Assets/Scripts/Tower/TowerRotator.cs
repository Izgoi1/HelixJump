using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * rotateSpeed;
                rb.AddTorque(Vector3.up * torque);
            }
        }
    }
}
