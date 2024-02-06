using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Spawner> spawners;

    void Start()
    {
        // Obt�n todos los Spawners en la escena
        spawners = new List<Spawner>(FindObjectsOfType<Spawner>());
    }

    public void SpawnerDestroyed(int spawnerID)
    {
        // Llamado cuando un Spawner es destruido
        // Remueve el Spawner de la lista
        spawners.RemoveAll(spawner => spawner.spawnerID == spawnerID);

        // Verifica si todos los Spawners han sido destruidos
        if (spawners.Count == 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        // C�digo de la victoria
        Debug.Log("�Victoria!");
    }
}

