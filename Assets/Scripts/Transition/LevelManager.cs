using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Awake()
    {
        animator.enabled = false;
        // Debug.Log("Masuk ke Awaker");
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // animator.SetTrigger("Start");
        animator.enabled = true;
        Debug.Log(animator);
        animator.Play("Transition Start", 0 , 0.0f);
        // animator.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        animator.Play("Transition end", 0 , 0.0f);
        Player.Instance.transform.position = new(0, -4.5f);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    void Update()
    {
        
    }
}
