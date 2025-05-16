using UnityEngine;

public class Portador : MonoBehaviour
{
    [Header("Datos del Portador")]
    public string nombre;
    public Vida vida;

    public virtual void Curar(int cantidad)
    {
        //vida.AfectarEstadistica(cantidad);
        vida.AfectarEstidistica(cantidad);
        Debug.Log($"{nombre} ha sido curado: +{cantidad} HP (Actual: {vida.ValorActual})");
    }

    public virtual void RecibirDaño(int cantidad)
    {
        vida.AfectarEstidistica(-cantidad);
        Debug.Log($"{nombre} ha recibido daño: -{cantidad} HP (Actual: {vida.ValorActual})");

        if (vida.ValorActual <= 0)
        {
            AlMorir();
        }
    }

    public virtual void AlMorir()
    {
        Debug.Log(nombre + " ha muerto.");
    }
}
