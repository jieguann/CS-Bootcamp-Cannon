using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{ [Header("Cannon Rotation")]
    [SerializeField] private float maxYRotation = 180f;
    [SerializeField] private float minYRotation = 15f;
    [SerializeField] private float maxXRotation = 75f;
    [SerializeField] private float minXRotation = 15f;
    [Tooltip("The speed the cannon rotates at")]
    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private Transform cannonBarrelTransform;
    [SerializeField] private Transform connonBaseTransform;

    [Header("Projectile Setting")]
    [SerializeField] private CannonBall projectileprefab;
    [SerializeField] private Transform projectileFirePoint;
    [SerializeField] private float projectileShootingForce;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimConnon();
        FireCannon();
    }

    private void AimConnon()
    {
        //rotate along the x axis
        float horizontal = Input.GetAxis("Mouse X");
        float newBaseRotation = connonBaseTransform.localRotation.eulerAngles.y + rotationSpeed * horizontal;

        //rotate the barrel along the y axis
        float vertical = Input.GetAxis("Mouse Y");
        float newBarrelRotation = cannonBarrelTransform.localRotation.eulerAngles.x - rotationSpeed * vertical;


        //limit the rotation
        newBaseRotation = Mathf.Clamp(newBaseRotation, minYRotation, maxYRotation);
        newBarrelRotation = Mathf.Clamp(newBarrelRotation, minXRotation, maxXRotation);

        //apply the rotation
        connonBaseTransform.localRotation = Quaternion.Euler(0,newBaseRotation,0);
        cannonBarrelTransform.localRotation = Quaternion.Euler(newBarrelRotation, 0,0);
    }

    private void FireCannon()
    {

        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }

        CannonBall cannonBall = Instantiate(projectileprefab, projectileFirePoint.position, Quaternion.identity);
        cannonBall.SetUp(projectileFirePoint.forward * projectileShootingForce);


    }
}
