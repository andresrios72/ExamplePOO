using UnityEngine;

public class TestsDisparo : MonoBehaviour
{
    public AgenteUno agente;
    public Portador objetivo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agente.UsarHabilidad(0, objetivo);
        }
    }
}
