using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{

    public GameObject LoadingScreen;
    public int defaultTeleportId = 2;
    public Slider progressSlider;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "LobbyTeleport")
        {
            LoadingScreen.SetActive(true);
            StartCoroutine(LoadAsynchronously(defaultTeleportId));
        }
        
       
    }
    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        LoadingScreen.SetActive(true);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressSlider.value = progress;
            Debug.Log("Slider progress: " + progress);
            yield return null;
        }
    }
}
