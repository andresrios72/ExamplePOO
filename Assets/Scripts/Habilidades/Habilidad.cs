using UnityEngine;

[CreateAssetMenu(fileName = "Habilidad", menuName = "Scriptable Objects/Habilidad")]
public abstract class Habilidad : ScriptableObject
{
    [Header("Información General")]
    public string nombre;
    public Sprite icono;
    public TipoHabilidad tipoHabilidad;

    [Header("Costos y Tiempo")]
    public int costo;
    public float coolDown;
    public float ultimoUso;

    public virtual bool PuedeUsarse(float tiempoActual)
    {
        Debug.Log($"[Cooldown] TiempoActual: {tiempoActual}, ÚltimoUso: {ultimoUso}, CoolDown: {coolDown}");

        return tiempoActual >= ultimoUso + coolDown;
    }

    public abstract void Ejecutar(Portador objetivo);
}
