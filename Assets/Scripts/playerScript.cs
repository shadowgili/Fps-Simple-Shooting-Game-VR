using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour
{
    private GameObject gun;
    private GameObject spawnPoint;
    private bool isShooting;
    
    void Start()
    {
        gun = gameObject.transform.GetChild(0).gameObject;
        spawnPoint = gun.transform.GetChild(0).gameObject;
        isShooting = false;
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
        rb.AddForce(spawnPoint.transform.forward * 500f);
        GetComponent<AudioSource>().Play();
        gun.GetComponentInChildren<Animation>().Play();
        Destroy(bullet, 2);
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }


    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 10000))
        {
            if (hit.collider.name.Contains("zombie"))
            {
                if (!isShooting)
                {
                    StartCoroutine("Shoot");

                }
            }
        }

    }
}