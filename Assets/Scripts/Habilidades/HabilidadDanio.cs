using UnityEngine;

[CreateAssetMenu(fileName = "HabilidadDanio", menuName = "Scriptable Objects/HabilidadDanio")]
public class HabilidadDanio : Habilidad
{
    [Header("Parámetros de Daño")]
    public int daño;
    public float radio;
    public float duracion;
    //public GameObject areaVisualPrefab;
    [Header("VFX y Audio")]
    public GameObject efectoVisual;

    public override void Ejecutar(Portador objetivo)
    {
        if (!PuedeUsarse(Time.time)) return;

        Vector3 posicionImpacto = objetivo.transform.position + objetivo.transform.forward * 3f; // 3m frente a ti
        posicionImpacto.y = 0.1f;

        //// Instanciar efecto visual (círculo o fuego)
        //if (areaVisualPrefab != null)
        //{
        //    GameObject visual = GameObject.Instantiate(areaVisualPrefab, posicionImpacto, Quaternion.identity);
        //    visual.transform.localScale = Vector3.one * radio * 2f; // ajustar al radio real
        //    GameObject.Destroy(visual, duracion);
        //}
        // VFX mágico
        if (efectoVisual != null)
        {
            GameObject fx = Instantiate(efectoVisual, posicionImpacto, Quaternion.identity);
            Destroy(fx, duracion); // Auto-destruir
        }

        // Detectar y dañar enemigos en el área
        Collider[] colisiones = Physics.OverlapSphere(posicionImpacto, radio);
        foreach (var col in colisiones)
        {
            Portador enemigo = col.GetComponent<Portador>();
            if (enemigo != null && enemigo != objetivo)
            {
                enemigo.RecibirDaño(daño);
                Debug.Log($"Daño AOE: {enemigo.nombre} recibe {daño} de daño.");
            }
        }

        ultimoUso = Time.time;
    }
}
