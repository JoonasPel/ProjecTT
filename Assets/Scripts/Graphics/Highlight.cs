using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{

    // This is changed from outside to true (in Update()) to tell this object highlight is needed
    // this is not changed to false from outside so it is checked in this script if more "trues"
    // are coming or not. TODO: better solution
    // bad solution because I dont know how to check for raycast exit yet.
    public bool highlightNeeded;

    Material material;

    // Set copy of material to object. To allow manipulating material without manipulating
    // other objects using same material
    void Awake()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = new Material(renderer.material);
        material = renderer.material; 
    }

    void FixedUpdate()
    {
        highlightNeeded = false;
    }

    void LateUpdate()
    {
        if (highlightNeeded)
        {
            Highlighter(true);
        }
        else
        {
            Highlighter(false);
        }
    }

    public void Highlighter(bool highlight)
    {
        if (highlight)
        {
            material.EnableKeyword("_EMISSION");   
        }
        else
        {
            material.DisableKeyword("_EMISSION");
        }             
    }
}
