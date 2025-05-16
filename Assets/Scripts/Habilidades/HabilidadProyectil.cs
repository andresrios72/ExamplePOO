using UnityEngine;

[CreateAssetMenu(fileName = "HabilidadProyectil", menuName = "Scriptable Objects/HabilidadProyectil")]
public class HabilidadProyectil : Habilidad
{
    [Header("Par�metros de Proyectil")]
    public GameObject prefabProyectil;
    public float fuerza;
    public float velocidad;

    public override void Ejecutar(Portador objetivo)
    {
        PortadorJugable pj = objetivo as PortadorJugable;
        if (pj == null || pj.camaraFPS == null || prefabProyectil == null)
        {
            Debug.LogWarning("No se puede lanzar proyectil: referencias faltantes.");
            return;
        }

        Transform puntoDisparo = pj.camaraFPS;

        GameObject proyectil = GameObject.Instantiate(
            prefabProyectil,
            puntoDisparo.position,
            Quaternion.LookRotation(puntoDisparo.forward)
        );

        Pproyectil componenteProyectil = proyectil.GetComponent<Pproyectil>();
        if (componenteProyectil != null)
        {
            componenteProyectil.danio = this.costo; // O cualquier otro valor (puedes agregar una variable específica)

            //componenteProyectil.efectoImpacto = efectoImpacto; // si lo pasas desde aquí
        }

        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = puntoDisparo.forward * velocidad;
            rb.AddForce(puntoDisparo.forward * fuerza, ForceMode.Impulse);
        }

        ultimoUso = Time.time;
    }
}
