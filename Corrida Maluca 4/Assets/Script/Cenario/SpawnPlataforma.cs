using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlataforma : MonoBehaviour
{
    //Esse item cria uma lista para colocar as prefabs do cenario
    // essa é uma lista de prefabs
    public List<GameObject> plataforms = new List<GameObject>();

     // esta é uma lista dos objettos instanciadaos
    public List<Transform> currentPlataforms = new List<Transform>();

    //essa variavel é utilizada para saber a distancia entre uma plataforma e outra
    public int offset;

    //variavel para refermcia o player na cena
    private Transform player;

    private Transform currentPlataformPoint;

    private int plataformIndex;
    // Start is called before the first frame update
    void Start()
    {
        //referenciando variuavl acima
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < plataforms.Count; i++ ) // aqui nos estamos instacialno uma varivavel local, e enquanto essa variavel for menor que a quantidade total da lista,a variavel sera incrementada
        {
            // esse metodo basicamente da spawn das plataformas para o presonagem se mover.
            Transform p = Instantiate(plataforms[i], new Vector3(0,0,i * 74), transform.rotation).transform;
            currentPlataforms.Add(p);
            offset += 74;
        }

        // essa liha esta armasenado na variavel o ponro finla da plataformna.
        currentPlataformPoint = currentPlataforms[plataformIndex].GetComponent<Plataform>().point;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlataformPoint.position.z;
        
        //esse if esta verificando se eu passai pela plataforma, se sim ela ira reposicionar.
        if ( distance >= 5)
        {
            Recycle(currentPlataforms[plataformIndex].gameObject);
            plataformIndex++;

            //,metodo para resetar a variavel 
            if (plataformIndex > currentPlataforms.Count - 1)
            {
                plataformIndex = 0;
            }

            currentPlataformPoint = currentPlataforms[plataformIndex].GetComponent<Plataform>().point;
        }
    }

    public void Recycle(GameObject plataform)
    {
         plataform.transform.position = new Vector3(0,0,offset);
         offset += 74;
    }
}
