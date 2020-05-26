using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private int value = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player =
             other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            // apply first-aid and remove the item
            player.FirstAid(value);
            Destroy(this.gameObject);
        }
    }


}
