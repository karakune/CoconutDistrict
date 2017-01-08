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

        //if (JunkPrefabTypes == null)
        //{
        //    Destroy(this.gameObject);
        //    print("WARNING un type de bébris n'est pas defini dans les prefab. Vérifier l'objet avec un component JunkSpanwer");
        //    return;
        //}

        

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

                var playerTheta = Mathf.Atan2(p.transform.position.y, p.transform.position.x);
           

                var angle = (360.0f + (((playerTheta * 180)) / Mathf.PI)) % 360;  ///TODO : a changer pour p.theta
                //print("angle:" + angle);

                var JunkType = Mathf.RoundToInt(Mathf.Floor(UnityEngine.Random.Range(0f, 3.999f)));

                float direction = (Mathf.Floor(UnityEngine.Random.Range(0.0f, 1.99f)) * 2 - 1);

                Instantiate(JunkPrefabTypes[JunkType],
                            direction * p.transform.position,
                            Quaternion.identity);
            }


        //Cooldown untill next random spawn
        SetTimer(NextSpawnTime, SpawnJunkEvent);
        StartTimer();
    }
}