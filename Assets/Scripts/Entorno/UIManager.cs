using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider barra;
    public PortadorJugable portador;
    public bool esVida = true;
    void Start()
    {
        if (portador != null && barra != null)
        {
            float max = esVida ? portador.vida.ValorMaximo : portador.mana.ValorMaximo;
            barra.maxValue = max;
            barra.minValue = 0;
        }
    }

    void Update()
    {
        if (portador == null || barra == null) return;

        float actual = esVida ? portador.vida.ValorActual: portador.mana.ValorActual;
        barra.value = actual;
    }
}
