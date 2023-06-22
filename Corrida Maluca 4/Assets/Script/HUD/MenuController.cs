using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //lista que armazena todos os layouts do menu.
   [SerializeField] private List<GameObject> _layouts;
    //variavel que indica qual layout é ativo primeiro.
    [SerializeField] private int _firstLayout;

    [SerializeField] private AudioSource _audioSourceFx;

    
    [SerializeField] private Slider _fxVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    private void Start()
    {
        StartLayout();
    }
    
    //metodo para gerenciar a inicialização do layou.
    private void StartLayout()
    {
        //atraves do for iremos desativar todos os gameobject que representam os layouts do menu
        for (int i = 0; i < _layouts.Count; i++)
        {
            _layouts[i].gameObject.SetActive(false);
        }
        //apos desativar todos os layouts. é necessario ativar
        //apenas o layout inicial (menu), pasand como parametro
        //a variavel _firstlayout que é definida no inspector
        _layouts[_firstLayout].gameObject.SetActive(true);
    }

    //metodo ativar layout
    public void EnableLayout(int indexLayout)
    {
        _layouts[indexLayout].gameObject.SetActive(true);
        GameManager.Instance.AudioManager.PlaySoundEffect(_audioSourceFx,0);
    }
     //metodo desativar layout
    public void DisableLayout(int indexLayout)
    {
        _layouts[indexLayout].gameObject.SetActive(false);
    }

    //metodo para fechar o jogo
    public void ExitGame()
    {
        Application.Quit();
    }

    //metodo para iniciar outra cena

    public void StartGame()
    {
        GameManager.Instance.SceneLoadManager.LoadScene("Fase_01");
    }

    public void MuteMusic()
    {
        //GameManager.Instance.AudioSource.MuteAudio();
    }
}
