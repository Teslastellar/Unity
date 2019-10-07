using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallThrough : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Don't need this line
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shootable"), LayerMask.NameToLayer("Shootable"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
