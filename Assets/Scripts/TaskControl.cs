using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskControl : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    private void Start()
    {
        UpdateTask("Find documents");
    }
    public void UpdateTask(string task)
    {
        taskText.text = "Objective : " + task;
    }
}
