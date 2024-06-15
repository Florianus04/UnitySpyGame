using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneControl : MonoBehaviour
{
    public bool isCollected = false;
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Cursor.visible = false;
    }
    public void ChangeScene(string scene)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(scene);
    }
    public void Document(bool collected)
    {
        isCollected = collected;
    }
    public void FinishGame(string scene)
    {
        if (isCollected)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(scene);
        }      
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PointerEnter(GameObject target)
    {
        target.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }
    public void PointerExit(GameObject target)
    {
        target.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
    }
}
