using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Guardando as classes manager dentro de uma variavel para que
    //seja possivel acessa-las atraves da classe GameManager
    public static GameManager Instance;
    [Header("Managers")]
    [SerializeField] private SceneLoadManager _sceneLoadManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Já existe uma istacia dessa class!");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }    
        //metodo para que o metodo game manager não seja destroido.
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        //acesando a classe scene load manager para carregar o metodo loadScene
        _sceneLoadManager.LoadScene("Menu");
    }


    //propiedade que faz com que seja possivel acessar o scene load manager para conseguir fazer atroca de cena.
    public SceneLoadManager SceneLoadManager => _sceneLoadManager;

    // Update is called once per frame
    void Update()
    {
        
    }
}
