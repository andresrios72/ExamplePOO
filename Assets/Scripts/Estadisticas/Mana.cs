using UnityEngine;

[System.Serializable]
public class Mana : Estadistica
{
    public TipoCarga tipoCaga;
    public Mana(int min, int max, int actual, TipoCarga tipo) : base(min, max, actual)
    {
        tipoCaga = tipo;
    }
}
