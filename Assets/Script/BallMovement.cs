using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //[SerializeField] private float horizontal = Input.GetAxis("Horizontal");
    //[SerializeField] private float vertical = Input.GetAxis("Vertical");
    [SerializeField] private float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float newXRotation = transform.localRotation.eulerAngles.x + horizontal * rotationSpeed;
        //float newYRotation = transform.localRotation.eulerAngles.y + vertical * rotationSpeed;
    }
}
