using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlocManager : MonoBehaviour {

    [SerializeField]
    Color additionColor;

    [SerializeField]
    Color substractionColor;

    [SerializeField]
    Color multiplicationColor;

    [SerializeField]
    Color divisionColor;

    [SerializeField]
    Color noneColor;

    public static ColorBlocManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Color SetColorToBloc(Bloc.Operations operation)
    {
        switch (operation)
        {
            case Bloc.Operations.addition:
                return additionColor;
            case Bloc.Operations.substraction:
                return substractionColor;
            case Bloc.Operations.multiplication:
                return multiplicationColor;
            case Bloc.Operations.division:
                return divisionColor;
            case Bloc.Operations.none:
                return noneColor;
            default:
                return noneColor;
        }
    }
}
