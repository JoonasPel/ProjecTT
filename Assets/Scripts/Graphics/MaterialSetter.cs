using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set copy of material to object. To allow manipulating material without manipulating
// other objects using same material
public class MaterialSetter : MonoBehaviour
{
    void Awake()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = new Material(renderer.material);
    }
    
}
