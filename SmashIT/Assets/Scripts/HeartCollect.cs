using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCollect : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI info;
    public static int heartCount;

    void Start(){
        heartCount = 5;
        info.text = heartCount.ToString();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject == player){
            heartCount++;
            info.text = heartCount.ToString();

            GetComponent<AudioSource>().Play();
            Destroy(GetComponent<BoxCollider>());
            transform.position = new Vector3(0f, -1f, 0f);
        }
    }
}
