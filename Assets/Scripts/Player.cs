using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance;

    public int Number
    {
        get
        {
            if (numString != null && numString != "")
            {
                return int.Parse(numString);
            }
            else
                return -9999;
        }
    }

    [SerializeField]
    [Range(-3,3)]
    float speed = 1;

    [SerializeField]
    float timeToType = 1.5f;

    [SerializeField]
    TextMeshProUGUI tmpTxt;

    string numString;

    float timer = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timer = timeToType;
    }

    void Update () {
        string inputStr = Input.inputString;
        int number;
        if (inputStr != "" && int.TryParse(inputStr, out number))
        {
            ResetTimer();
            numString += inputStr;
        }

        if (timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;

        if (timer <= 0)
            Clear();

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        tmpTxt.text = numString;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Clear();
        }
    }

    public void MoveToBloc(Bloc bloc)
    {
        Clear();
        transform.position = bloc.transform.position;
    }

    private void ResetTimer()
    {
        timer = timeToType;
    }

    private void Clear()
    {
        numString = "";
    }
}
