using UnityEngine;

[System.Serializable]
public class Vida : Estadistica
{
    public TipoCarga tipoCarga;

    public Vida(int min, int max, int actual, TipoCarga tiCarga) : base(min, max, actual)
    {
        tipoCarga = tiCarga;
    }
}
