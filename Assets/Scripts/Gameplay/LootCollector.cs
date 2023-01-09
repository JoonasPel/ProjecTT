using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used to collect loot from ground. Will check all the time and show some message when player is aiming collectable.
public class LootCollector : MonoBehaviour
{   
    private Ray ray;
    private RaycastHit hitData;
    private Vector3 center = new Vector3(0.5f, 0.5f, 0);
    private int layerMask = 1 << 10;
    private float rayMaxDistance = 10f;

    public GameObject player;
    private Animator playerAnimator;

    void Awake()
    {
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {
        ray = Camera.main.ViewportPointToRay(center);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red); // Draw ray in scene view
        
        if (Physics.Raycast(ray, out hitData, rayMaxDistance, layerMask))
        {
            Transform collectable = hitData.transform;
            // highlight collectable object when aiming it.
            collectable.GetComponent<Highlight>().highlightNeeded = true;
            // pickup item
            if (Input.GetKeyDown(KeyCode.E)) // TODO: change to use new input system
            {
                // increase player resource
                if (ResourceManager.Instance.IncreaseResource("goldCoins", 10))
                {
                    playerAnimator.SetTrigger("PickUpItem"); // TODO: stringtohash
                    Destroy(collectable.gameObject); // TODO: destroy after delay (syncs better with animation)
                    Debug.Log("<color=green>Collected item: </color>" + collectable.parent.name);
                }
                else
                {
                    Debug.LogError("CANTTT collect item: " + collectable.parent.name);
                }         
            }
        }        
    }
}
