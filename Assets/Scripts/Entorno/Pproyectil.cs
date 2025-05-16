using UnityEngine;

public class Pproyectil : MonoBehaviour
{
    public int danio = 20;
    public GameObject efectoImpacto;
    public int tiempoAutoDestruir = 5;

    private void Start()
    {
        Destroy(gameObject, tiempoAutoDestruir);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Solo continuar si el objeto tiene el tag "Enemigo"
        if (!other.CompareTag("Enemigo")) return;

        Portador portador = other.GetComponent<Portador>();
        if (portador != null)
        {
            portador.RecibirDaño(danio);
            Debug.Log($"{portador.nombre} ha recibido {danio} de daño por proyectil.");
        }
        // Efecto visual
        if (efectoImpacto != null)
        {
            Instantiate(efectoImpacto, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
