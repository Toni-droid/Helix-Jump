using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        player.ReachFinish();
        for (float i = 0; i < 0.8; i+=0.2f )
        {
            rend.material.SetFloat("_DisolveAmount", i);
        }
    }
}
