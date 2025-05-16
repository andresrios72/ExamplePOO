using System.Collections.Generic;
using UnityEngine;

public class ZonaDanio : MonoBehaviour
{
    public int dañoPorTic = 1;
    public float intervalo = 0.1f;

    private Dictionary<Portador, float> tiempoSiguienteTic = new Dictionary<Portador, float>();

    private void OnTriggerStay(Collider other)
    {
        Portador portador = other.GetComponent<Portador>();
        if (portador != null)
        {
            // Inicializar si no está en el diccionario
            if (!tiempoSiguienteTic.ContainsKey(portador))
                tiempoSiguienteTic[portador] = Time.time;

            // Aplicar daño si pasó el intervalo
            if (Time.time >= tiempoSiguienteTic[portador])
            {
                portador.RecibirDaño(dañoPorTic);
                tiempoSiguienteTic[portador] = Time.time + intervalo;
                Debug.Log("El personaje esta recibiendo daño");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Limpiar del diccionario cuando sale
        Portador portador = other.GetComponent<Portador>();
        if (portador != null && tiempoSiguienteTic.ContainsKey(portador))
        {
            tiempoSiguienteTic.Remove(portador);
        }
    }
}
