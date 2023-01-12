using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
     public CharacterJoint[] joints;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FreezeRagdoll", 1.5f);
    }

    // joint has to be destroyed because making rigidbodies kinematic freezes ragdoll but also disables gravity.
    // i want the character to freeze but still have gravity.
    private void FreezeRagdoll()
    {
        joints = GetComponentsInChildren<CharacterJoint>();
        foreach (CharacterJoint joint in joints)
        {
            Destroy(joint);
        }
    }
    
}
