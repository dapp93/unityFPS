using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStates { alive, dead };



public class WanderingAI : MonoBehaviour
{//We need variables to hold references to the LaserBeam Prefab and a LaserBeam Game Object that will be rendered in the Scene
    [SerializeField] private GameObject laserbeamPrefab;
    private GameObject laserbeam;
    //Two variables that will control the rate-of-fire of the Enemy
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;



    private EnemyStates state;
    private float enemySpeed = 3.0f;
    private float baseSpeed = 0.2f;
    private float obstacleRange = 5.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
       
       
        state = EnemyStates.alive;
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the Enemy is alive
        if (state== EnemyStates.alive)
        {
           

       // Move Enemy and generate Ray
       transform.Translate(0, 0, enemySpeed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);

        // Spherecast and determine if Enemy needs to turn
        RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    // Spherecast hit Player, fire laser!
                    if (laserbeam == null && Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;

                        laserbeam = Instantiate(laserbeamPrefab) as GameObject;
                        laserbeam.transform.position =
                        transform.TransformPoint(0, 1.5f, 1.5f);
                        laserbeam.transform.rotation = transform.rotation;
                    }

                }
                else if (hit.distance < obstacleRange)
                {
                    // Must've hit wall or other object, turn
                    //added unityengine.
                    float turnAngle = UnityEngine.Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle, 0);
                }
            }


        }
    }
    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.DIFFICULTY_CHANGED,
            OnDifficultyChanged);
    }

    private void OnDifficultyChanged(float difficulty)
    {

        //You need to establish a baseSpeed (of about 0.1), 
        //and then set enemySpeed when OnDifficultyChanged() is called... but base it on your baseSpeed
        //float difficulty =2.0f;
        //possibly add a speed variable
        float difficultyDelta = 0.3f;
        //float Speed = 0.1f;// the change in speed per level of difficulty
        enemySpeed = baseSpeed + (difficulty * difficultyDelta); // should do it.

        Debug.Log("wandering ai speed changed to " + enemySpeed);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.DIFFICULTY_CHANGED,
            OnDifficultyChanged);
    }


}
