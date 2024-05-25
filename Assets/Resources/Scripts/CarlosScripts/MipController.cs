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
        if (agent.destination.x == transform.position.x && agent.destination.z == transform.position.z)
        {
            if (anim.GetBool("planting") == false) agent.destination = RandomPosition();
        }
    }
    

    public IEnumerator Plant()
    {
        agent.ResetPath();
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(rnd.Next(10,20));
        anim.SetBool("planting", true);
        yield return Plant();

    }

    public void InstantiatePlant()
    {
        Instantiate(plant, transform.position, Quaternion.identity, GameObject.Find("Arbolitos").transform);
        anim.SetBool("planting", false);
        GameManager.Instance.score += 1;
        agent.destination = RandomPosition();
    }

    public void Grab()
    {
        isGrabbed = true;
        agent.ResetPath();
        agent.enabled = false;
        anim.SetBool("grabbed", true);
    }

    public void Release()
    {
        isGrabbed = false;
        agent.enabled = true;
        agent.destination = RandomPosition();
        anim.SetBool("grabbed", false);
    }


    //Una funcion que me devuelva una posicion aleatoria en el plano
    public Vector3 RandomPosition()
    {
        float x = Random.Range(-plane.transform.localScale.x * 4, plane.transform.localScale.x * 4);
        float z = Random.Range(-plane.transform.localScale.z * 4, plane.transform.localScale.z * 4);
        return new Vector3(x, 0, z);
    }




}
