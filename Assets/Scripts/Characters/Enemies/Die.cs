using System.Collections;
using UnityEngine;

public class Die : State 
{


    public override void Start()
    {
        SpawnRandom();
        GameObject.Destroy(character.gameObject);
    }

    public override void Update()
    {

    }


    public override void FixedUpdate()
    {
        
    }

    public void SpawnRandom()
    {
        GameObject.Instantiate (character._droppables[UnityEngine.Random.Range(0, character._droppables.Length - 1)], character.transform.position, Quaternion.identity);
    }


    public Die (EnemyBehavior character) : base (character)
    {
        
    }
}