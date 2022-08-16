using System;
using UnityEngine;


public class BreakingPlatforms : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
      
    }

   
}
