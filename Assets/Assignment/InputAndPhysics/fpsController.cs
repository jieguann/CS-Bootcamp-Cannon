using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    //private Rigidbody cRig;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float maxRotation;
    [SerializeField] private float minRotation;

    // Start is called before the first frame update
    void Start()
    {
        //cRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePosition();
        moveRotation();
        
    }

    void movePosition()
    {
        //WSAD movement position
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 newPosition = new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0, moveVertical * moveSpeed * Time.deltaTime);


        //Debug.Log(moveHorizontal);
        //cRig.AddForce(newHorizontal,ForceMode.Impulse);
        transform.position += transform.forward * moveVertical * moveSpeed * Time.deltaTime;
        transform.position += transform.right * moveHorizontal * moveSpeed * Time.deltaTime;
    }

    void moveRotation()
    {
        //mouse Ratation 
        float rotationHorizontal = Input.GetAxis("Mouse X");
        float newXRotation = transform.localRotation.eulerAngles.y + rotationSpeed * rotationHorizontal;
        //Debug.Log(rotationHorizontal);
        //Debug.Log(rotationHorizontal);

        float rotationVertical = Input.GetAxis("Mouse Y");
        float newYRotation = transform.localRotation.eulerAngles.x + rotationSpeed * rotationVertical;
        //Debug.Log(transform.localRotation.eulerAngles.x);

        newYRotation = Mathf.Clamp(newYRotation, minRotation, maxRotation);
        //Debug.Log(newXRotation);
        transform.localRotation = Quaternion.Euler(newYRotation, newXRotation, 0);
        //transform.localRotation = Quaternion.Euler(newYRotation, 0, 0);
    }
}
