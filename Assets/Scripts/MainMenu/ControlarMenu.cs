using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlarMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameClick() //fun��o a ser chamada atarv�s do inspector do Bot�o (ver Button na Scene)
    {
        Debug.Log("new game click");
        SceneManager.LoadScene(1); //SceneManager.LoadScene("SampleScene"); //faz load de uma nova Scene
    }

    public void ExitClick() //fun��o a ser chamada atarv�s do inspector do Bot�o (ver Button (1) na Scene)
    {
        Debug.Log("exit click");
        Application.Quit(); //Fecha a aplica��o; n�o corre no editor
    }
}
