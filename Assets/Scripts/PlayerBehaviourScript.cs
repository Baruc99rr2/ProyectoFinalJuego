using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float VelocidadMovimiento = 5f;
    public float VelocidadRotacion = 100f;
    private float x, y;


    void Update()
    {
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * VelocidadMovimiento * x);
        transform.Rotate(Vector3.up * y * Time.deltaTime * VelocidadRotacion);
    }
}
