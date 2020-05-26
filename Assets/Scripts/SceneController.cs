using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;

    private GameObject enemy;
    private GameObject iguanaPatrol;

    private int numberOfEnemy;
    private int numberOfIguana;

    private GameObject[] enemyList;
    private GameObject[] iguanaList;

    // Update is called once per frame

    private void Start()
    {
        numberOfEnemy = 5;
        numberOfIguana = 5;

        enemyList = new GameObject[numberOfEnemy];
        iguanaList = new GameObject[numberOfIguana];

        for (int i = 0; i < iguanaList.Length; i++)
        {
            if (iguanaList[i] == null)
            {

                iguanaPatrol = Instantiate(iguanaPrefab) as GameObject;
                switch (i)
                {
                    case 0:
                        iguanaPatrol.transform.position = new Vector3(19, 0, 19);
                        break;

                    case 1:
                        iguanaPatrol.transform.position = new Vector3(19, 0, -19);
                        break;

                    case 2:
                        iguanaPatrol.transform.position = new Vector3(-19, 0, 19);
                        break;
                    case 3:
                        iguanaPatrol.transform.position = new Vector3(-19, 0, -19);
                        break;



                    default:
                        break;
              

                }
                
                float angle = Random.Range(0, 360);
                iguanaPatrol.transform.Rotate(0, angle, 0);
                iguanaList[i] = iguanaPatrol;
               

            }
        }

    }
    void Update()
    {
        for(int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i] == null)
            {

                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(0, 0, 5);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                enemyList[i] = enemy;
            }
        }

        
    }
}