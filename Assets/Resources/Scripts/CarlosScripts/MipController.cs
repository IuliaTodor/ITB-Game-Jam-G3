using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MipController : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private Animator anim;

    public bool isGrabbed = false;

    public GameObject plane;
    public GameObject plant;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = RandomPosition();
        StartCoroutine(Plant());
    }

    
    // Update is called once per frame
    void Update()
    {
        if (agent.destination.x == transform.position.x && agent.destination.z == transform.position.z) agent.destination = RandomPosition();
    }
    

    public IEnumerator Plant()
    {
        Instantiate(plant,transform.position, Quaternion.identity, GameObject.Find("Arbolitos").transform);
       
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(rnd.Next(5,10));
        yield return Plant();

    }


    //Una funcion que me devuelva una posicion aleatoria en el plano
    public Vector3 RandomPosition()
    {
        float x = Random.Range(-plane.transform.localScale.x * 4, plane.transform.localScale.x * 4);
        float z = Random.Range(-plane.transform.localScale.z * 4, plane.transform.localScale.z * 4);
        return new Vector3(x, 0, z);
    }




}
