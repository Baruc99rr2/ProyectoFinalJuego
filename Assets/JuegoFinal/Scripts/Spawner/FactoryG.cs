using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FactoryG : MonoBehaviour
{


    [SerializeField] private Generadores[] listaG;
    private Dictionary<string, Generadores> idToGenerador;


    private void Awake()
    {
        idToGenerador = new Dictionary<string, Generadores>();
        foreach (var generadores in listaG) 
        {

            idToGenerador.Add(generadores.Id, generadores);

        }
    }


    public Generadores Create(string id)
    {

        if (!idToGenerador.TryGetValue(id, out var generadores))
        {
            throw new Exception($"Generador with id {id} does not exist");
        }
        return Instantiate(generadores, transform.position, transform.rotation); 
    }

}
