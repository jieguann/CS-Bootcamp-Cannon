using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("WaterTrigger")))
        {
            Destroy(gameObject);
        }
        
    }
}
