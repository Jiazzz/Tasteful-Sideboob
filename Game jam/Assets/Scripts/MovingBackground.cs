using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

    private void Update()
    {
        MeshRenderer mr =  GetComponent<MeshRenderer>();
        Material material = mr.material;

        Vector2 offset = material.mainTextureOffset;

        offset.y = transform.position.y / transform.localScale.y;
        offset.x = transform.position.x / transform.localScale.x;

        material.mainTextureOffset = offset;
    }

    

    
	
}
