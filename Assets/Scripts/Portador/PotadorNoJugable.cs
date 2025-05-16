using UnityEngine;

public class PotadorNoJugable : Portador
{
    private SpawnerEnemigo spawner;
    public void asignarSpawner(SpawnerEnemigo _spawner)
    {
        spawner = _spawner;
    }

    public override void AlMorir()
    {
        Debug.Log($"{nombre} ha muerto. Iniciando respawn...");
        spawner?.IniciarRespawn();
        Destroy(gameObject); // Elimina al enemigo actual
    }
}
