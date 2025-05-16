using System.Collections.Generic;
using UnityEngine;

public class ZonaRecargaMana : MonoBehaviour
{
    public int manaPorTic = 1;
    public float intervalo = 0.25f;

    private Dictionary<PortadorJugable, float> siguienteTic = new Dictionary<PortadorJugable, float>();

    private void OnTriggerStay(Collider other)
    {
        PortadorJugable portador = other.GetComponent<PortadorJugable>();
        if (portador != null && portador.mana != null)
        {
            if (!siguienteTic.ContainsKey(portador))
                siguienteTic[portador] = Time.time;

            if (Time.time >= siguienteTic[portador])
            {
                portador.mana.AfectarEstidistica(manaPorTic);
                siguienteTic[portador] = Time.time + intervalo;
                Debug.Log($"{portador.nombre} recuperó {manaPorTic} maná en la zona.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PortadorJugable portador = other.GetComponent<PortadorJugable>();
        if (portador != null && siguienteTic.ContainsKey(portador))
        {
            siguienteTic.Remove(portador);
        }
    }
}
