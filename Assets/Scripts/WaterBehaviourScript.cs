using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviourScript : MonoBehaviour
{
    public BoxCollider PlayerCollider;
    public BoxCollider ColliderDesabled;

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") { }
        {
            ColliderDesabled = PlayerCollider;
            if (other.tag == "Player")
            {
                PlayerCollider.enabled = false;
            }
        }
    }
}