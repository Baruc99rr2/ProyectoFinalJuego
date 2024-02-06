using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawnerID; // Asigna un valor único a cada Spawner desde el inspector
    public GameController gameController; // Asigna la referencia al GameManager desde el inspector

    void Start()
    {
        // Registra el Spawner en el GameManager
        gameController.spawners.Add(this);
    }

    void OnDestroy()
    {
        // Notifica al GameManager que el Spawner ha sido destruido
        gameController.SpawnerDestroyed(spawnerID);
    }

    // Otro código del spawner
}
