using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class enemySpawner : MonoBehaviour
{
    public TMP_Text winText;
    public const int MAX_ENEMY = 15;

    GameObject[] enemy = new GameObject[MAX_ENEMY];
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
        winText.gameObject.SetActive(false);
        for (int i = 0; i < MAX_ENEMY; i++)
        {
         
            
            Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(-8.0f, 8.0f), UnityEngine.Random.Range(-4.0f, 4.0f), -1);

            Instantiate(prefab, enemyPosition,Quaternion.identity,this.transform);

            enemy[i] = prefab;
        }
    }

    // Update is called once per frame
    void Update()
    {
            if(whateverNameyouWANt())
            {
                winText.text = "You Win";
                winText.gameObject.SetActive(true);
            }
    }

    bool whateverNameyouWANt()
    {
        for(int i = 0; i < MAX_ENEMY;i++)
        {
            if (this.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
