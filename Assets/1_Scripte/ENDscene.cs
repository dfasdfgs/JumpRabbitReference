using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENDscene : MonoBehaviour
{
    public DataBaseManager dataBaseManager;
    public Text H_Scor;

    void Start()
    {
        H_Scor.text = "����� �ְ��� : " + dataBaseManager.H_sco.ToString("F1");
    }

    void Update()
    {
        
    }
}
