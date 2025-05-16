using System.Collections;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float tiempoRespawn = 5f;

    private GameObject enemigoInstanciado;
    void Start()
    {
        // Instancia inicial
        enemigoInstanciado = Instantiate(enemigoPrefab, transform.position, transform.rotation);
        enemigoInstanciado.GetComponent<PotadorNoJugable>().asignarSpawner(this);
    }
    public void IniciarRespawn()
    {
        StartCoroutine(Respawn());
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(tiempoRespawn);

        enemigoInstanciado = Instantiate(enemigoPrefab, transform.position, transform.rotation);
        enemigoInstanciado.GetComponent<PotadorNoJugable>().asignarSpawner(this);
    }
}
