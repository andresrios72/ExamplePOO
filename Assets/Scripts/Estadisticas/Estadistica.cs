using UnityEngine;

[System.Serializable]
public class Estadistica
{
    [SerializeField] protected int valorMinimo;
    [SerializeField] protected int valorMaximo;
    [SerializeField] protected int valorActual;
    public int ValorActual => valorActual;
    public int ValorMaximo => valorMaximo;
    public int ValorMinimo => valorMinimo;
    public Estadistica(int min, int max, int actual)
    {
        valorMinimo = min;
        valorMaximo = max;
        valorActual = Mathf.Clamp(actual, min, max);
    }

    public virtual void AfectarEstidistica(int catindad)
    {
        valorActual = Mathf.Clamp(valorActual +  catindad, valorMinimo, valorMaximo);
    }
}
