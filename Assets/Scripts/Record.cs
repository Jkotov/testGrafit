using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Record : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "Record: " + PlayerPrefs.GetInt("score", 0).ToString();
    }
}
