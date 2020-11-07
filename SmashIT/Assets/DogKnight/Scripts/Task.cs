using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public GameObject info;
    public GameObject setting;
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
            info.SetActive(true);
        else
            info.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            setting.SetActive(!setting.active);
    }
}
