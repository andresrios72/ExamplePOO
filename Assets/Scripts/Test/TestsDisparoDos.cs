using UnityEngine;

public class TestsDisparoDos : MonoBehaviour
{
    public AgenteDos agente;
    public Portador objetivo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Por ejemplo, tecla "E"
        {
            agente.UsarHabilidad(0, objetivo);
        }
    }
}
