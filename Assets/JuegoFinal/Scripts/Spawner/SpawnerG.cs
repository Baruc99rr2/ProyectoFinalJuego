using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerG : MonoBehaviour
{
    [SerializeField] private FactoryG factoryg;
    [SerializeField] private bool spawnCar1;
    [SerializeField] private bool spawnCar2;
    [SerializeField] private bool spawnCar3;
    [SerializeField] private bool spawnCar4;

    [SerializeField] private float intervalCar1 = 2f; // Intervalo entre creaciones para car1
    [SerializeField] private float intervalCar2 = 3f; // Intervalo entre creaciones para car2
    [SerializeField] private float intervalCar3 = 4f; // Intervalo entre creaciones para car3
    [SerializeField] private float intervalCar4 = 5f; // Intervalo entre creaciones para car4

    private float timerCar1;
    private float timerCar2;
    private float timerCar3;
    private float timerCar4;

    private void Update()
    {
        if (spawnCar1)
        {
            timerCar1 += Time.deltaTime;
            if (timerCar1 >= intervalCar1)
            {
                factoryg.Create("car1");
                timerCar1 = 0f;
            }
        }

        if (spawnCar2)
        {
            timerCar2 += Time.deltaTime;
            if (timerCar2 >= intervalCar2)
            {
                factoryg.Create("car2");
                timerCar2 = 0f;
            }
        }

        if (spawnCar3)
        {
            timerCar3 += Time.deltaTime;
            if (timerCar3 >= intervalCar3)
            {
                factoryg.Create("car3");
                timerCar3 = 0f;
            }
        }

        if (spawnCar4)
        {
            timerCar4 += Time.deltaTime;
            if (timerCar4 >= intervalCar4)
            {
                factoryg.Create("car4");
                timerCar4 = 0f;
            }
        }
    }
}