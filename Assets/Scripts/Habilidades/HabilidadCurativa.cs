using UnityEngine;

[CreateAssetMenu(fileName = "HabilidadCurativa", menuName = "Scriptable Objects/HabilidadCurativa")]
public class HabilidadCurativa : Habilidad
{
    [Header("Parámetros de Curación")]
    public bool curacionCompleta = true;
    public int cantidadCuracion = 25;

    public override void Ejecutar(Portador objetivo)
    {
        if (!PuedeUsarse(Time.time)) return;

        int cantidad = curacionCompleta
            ? (objetivo.vida.ValorMaximo - objetivo.vida.ValorActual)
            : cantidadCuracion;

        objetivo.Curar(cantidad);
        ultimoUso = Time.time;

        Debug.Log($"{objetivo.nombre} ha sido curado: +{cantidad} HP.");
    }
}
