using System.Collections.Generic;
using UnityEngine;

public class AgenteUno : PortadorJugable
{
    public List<Habilidad> HabilidadesIniciales;
    public UIHabilidad[] habilidadUI;
    //private void Start()
    //{
    //    foreach (var habilidad in HabilidadesIniciales)
    //    {
    //        habilidad.ultimoUso = -999f; // Reseteo total
    //        sistemaHabilidades.AgregarHabilidad(habilidad);
    //    }
    //}
    private void Start()
    {
        for (int i = 0; i < HabilidadesIniciales.Count && i < habilidadUI.Length; i++)
        {
            sistemaHabilidades.AgregarHabilidad(HabilidadesIniciales[i]);
            habilidadUI[i].Configurar(HabilidadesIniciales[i], ObtenerLetra(i));
            HabilidadesIniciales[i].ultimoUso = -999f; // reset
        }
    }

    private string ObtenerLetra(int index)
    {
        return index switch
        {
            0 => "Q",
            1 => "E",
            2 => "R",
            _ => ""
        };
    }
    public override void UsarHabilidad(int index, Portador objetivo)
    {
        Habilidad habilidad = sistemaHabilidades.ObtenerHabilidad(index);

        if (habilidad == null)
        {
            Debug.LogWarning("Habilidad no encontrada.");
            return;
        }
        if (vida.ValorActual >= habilidad.costo && habilidad.PuedeUsarse(Time.time))
        {
            vida.AfectarEstidistica(-habilidad.costo);
            habilidad.Ejecutar(objetivo);
            Debug.Log($"{nombre} usó {habilidad.nombre} con vida (-{habilidad.costo}).");
        }
        else
        {
            Debug.Log($"{nombre} no puede usar {habilidad.nombre}: vida insuficiente o en cooldown.");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UsarHabilidad(0, this); // Habilidad Curativa sobre uno mismo
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UsarHabilidad(1, this); // Habilidad de Daño
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UsarHabilidad(2, this); // Proyectil, apunta hacia donde mira
        }
    }
}
