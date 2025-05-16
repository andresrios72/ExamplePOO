using UnityEngine;
using UnityEngine.UI;

public class UIHabilidad : MonoBehaviour
{
    public Image iconoHabilidad;
    public Image overlayCooldown;
    public Text teclaUI;

    [HideInInspector] public Habilidad habilidad;

    void Update()
    {
        if (habilidad == null || overlayCooldown == null) return;

        float tiempoRestante = (habilidad.ultimoUso + habilidad.coolDown) - Time.time;
        float ratio = Mathf.Clamp01(tiempoRestante / habilidad.coolDown);
        overlayCooldown.fillAmount = ratio;
    }

    public void Configurar(Habilidad habilidadAsignada, string tecla)
    {
        habilidad = habilidadAsignada;
        if (iconoHabilidad != null) iconoHabilidad.sprite = habilidad.icono;
        if (teclaUI != null) teclaUI.text = tecla;
    }
}
