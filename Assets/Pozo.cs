using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozo : MonoBehaviour
{
    public GameObject rechargePanel;
    public Gun gun;

    private void Awake()
    {
        gun = GetComponent<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rechargePanel.SetActive(true);

            if(Input.GetKeyDown(KeyCode.R))
            {
                gun.Reload();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rechargePanel.SetActive(false);
        }
    }
}
