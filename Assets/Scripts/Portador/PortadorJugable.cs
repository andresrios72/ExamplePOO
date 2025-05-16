using UnityEngine;

public class PortadorJugable : Portador
{
    [Header("Camara")]
    public Transform camaraFPS;

    [Header("Recurso Mágico")]
    public Mana mana;

    [Header("Sistema de Habilidades")]
    public SistemaHabilidades sistemaHabilidades = new SistemaHabilidades();

    public virtual void UsarHabilidad(int index, Portador objetivo)
    {
        sistemaHabilidades.LanzarHabilidad(index, objetivo);
    }
    public virtual Transform ObtenerPuntoDisparo()
    {
        return camaraFPS;
    }
}
