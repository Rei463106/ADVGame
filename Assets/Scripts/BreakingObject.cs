using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakingObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ItemGet.notitem == 1 && this.gameObject.name == "Key")
        {
           Destroy(this.gameObject);
        }
        if(ItemGet.notitem2 == 1 && this.gameObject.name == "AquaProtein")
        {
            Destroy(this.gameObject);
        }
        if (ItemGet.notitem3 == 1 && this.gameObject.name == "FireProtein")
        {
            Destroy (this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
