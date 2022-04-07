using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D collider;
    void Start()
    {
        tag = "PressurePlate";
        collider = this.gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
