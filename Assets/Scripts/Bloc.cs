using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bloc : MonoBehaviour {

    public Operations operation;

    public int number;

    [SerializeField]
    List<Bloc> connectedBlocs;

    [SerializeField]
    SpriteRenderer spriteR;

    [SerializeField]
    TextMeshProUGUI tmptxt;

    private void Start()
    {
        spriteR.color = ColorBlocManager.Instance.SetColorToBloc(operation);
        tmptxt.text = number.ToString();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (connectedBlocs.Count != 0)
            {
                foreach (Bloc bloc in connectedBlocs)
                {
                    if (Calculate(number, bloc.number, bloc.operation) == Player.Instance.Number)
                    {
                        Player.Instance.MoveToBloc(bloc);
                    }
                }
            }
        }
    }

    public int Calculate(int numberOfBloc, int numberOtherBloc, Operations operation)
    {
        float number = 0;
        switch (operation)
        {
            case Operations.addition:
                number = numberOfBloc + numberOtherBloc;
                break;
            case Operations.substraction:
                number = numberOfBloc - numberOtherBloc;
                break;
            case Operations.multiplication:
                number = numberOfBloc * numberOtherBloc;
                break;
            case Operations.division:
                number = numberOfBloc / numberOtherBloc;
                break;
            case Operations.none:
                number = numberOtherBloc;
                break;
            default:
                number = numberOfBloc;
                break;
        }

        return Mathf.RoundToInt(number);
    }

    public enum Operations
    {
        addition,
        substraction,
        multiplication,
        division,
        none
    }

}
