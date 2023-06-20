using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //metodo para carregar a cena menu
    public void MenuLoad()
    {
        GameManager.Instance.SceneLoadManager.LoadScene("Menu");
    }
     //metodo para carregar a cena Fase 1
    public void Fase01Load()
    {
        GameManager.Instance.SceneLoadManager.LoadScene("Fase_01");
    }
}
