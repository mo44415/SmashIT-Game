using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollect : MonoBehaviour
{
    public GameObject player;
    public GameObject diamondImage;

    void OnTriggerEnter(Collider other){
        if(other.gameObject == player){
            GetComponent<AudioSource>().Play();
            Destroy(GetComponent<BoxCollider>());
            transform.position = new Vector3(0f, -1f, 0f);
            diamondImage.SetActive(true);
        }
    }
}
