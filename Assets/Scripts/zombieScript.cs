using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class zombieScript : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    
    // Use this for initialization
    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
  
    }

    private void Update()
    {
        agent.destination = goal.position;
        GetComponent<Animation>().Play("Z_Walk");
    }

    void OnTriggerEnter(Collider col)
    {
        GetComponent<CapsuleCollider>().enabled = false;
        //Destroy(col.gameObject);
        agent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        Debug.Log("Guli khaise");
        GetComponent<Animation>().Play("Z_FallingForward");
        Debug.Log("Pore na kn");
        Destroy(gameObject);
        Score.score += 1;
        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);

        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
        {

            randomX = UnityEngine.Random.Range(-12f, 12f);
            randomZ = UnityEngine.Random.Range(-13f, 13f);

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);

            
        }

    }

}
