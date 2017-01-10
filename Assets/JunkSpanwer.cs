using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class JunkSpanwer : TimerFunctionsClass
{
    public float NextSpawnTime = 1.0f;
    public List<GameObject> JunkPrefabTypes = new List<GameObject>();
    public bool GenerationVersLesjoueurs = false;  //random lorsque false;

    // Use this for initialization
    public void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Debris"), LayerMask.NameToLayer("Debris"));
       
        if (GenerationVersLesjoueurs) NextSpawnTime = 3 * NextSpawnTime;
        this.SetTimer(NextSpawnTime, SpawnJunkEvent);
        this.StartTimer();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }

    public void SpawnJunkEvent()
    {
         
 
            var players = GameObject.FindGameObjectsWithTag("Player");

            foreach (var p in players)
            {

                //arrêter de générer des asteroides si player ejecté (sinon on se rends compte d,une ligne d'astéroides)
                //Astronaut a = p.GetComponent<Astronaut>();
                //if (a.State >= Astronaut.AstronautState.Ejecting)
                //    continue; //next player;
 
                var JunkType = Mathf.RoundToInt(Mathf.Floor(UnityEngine.Random.Range(0f, 13.999f)));

                float directionx = Mathf.Floor(UnityEngine.Random.Range(10.0f, 15.0f));
                Debug.LogWarning("direction1  " + directionx);
                directionx *= (Mathf.Floor(UnityEngine.Random.Range(0.0f, 1.99f)) * 2 - 1); // -1 ou 1
                Debug.LogWarning("direction2  " + directionx);
                float directiony = UnityEngine.Random.Range(-3.0f, 2.99f);

                var debris = Instantiate(JunkPrefabTypes[JunkType],
                                new Vector3(p.transform.position.x + directionx , p.transform.position.y + directiony) ,
                                Quaternion.identity);

                //add force vers le joueur
                debris.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(30f, 55f) * directionx * -1 ,10,0) * 2 * Time.deltaTime);

        }


        //Cooldown untill next random spawn
        SetTimer(NextSpawnTime, SpawnJunkEvent);
        StartTimer();
    }
}