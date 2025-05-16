using System.Collections.Generic;
using UnityEngine;

public class SistemaHabilidades
{
    [Header("Identificador")]
    public string nombre;

    [Header("Habilidades del personaje")]
    public List<Habilidad> habilidades = new List<Habilidad>();

    public void AgregarHabilidad(Habilidad habilidad)
    {
        if (habilidad != null && !habilidades.Contains(habilidad))
        {
            habilidades.Add(habilidad);
        }
    }
    public void LanzarHabilidad(int index, Portador objetivo)
    {
        if (index >= 0 && index < habilidades.Count)
        {
            Habilidad habilidad = habilidades[index];
            habilidad.Ejecutar(objetivo);
        }
        else
        {
            Debug.LogWarning("Índice de habilidad fuera de rango.");
        }
    }
    public Habilidad ObtenerHabilidad(int index)
    {
        if (index >= 0 && index < habilidades.Count)
        {
            return habilidades[index];
        }
        return null;
    }
}
