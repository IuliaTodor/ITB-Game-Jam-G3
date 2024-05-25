using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pozo : MonoBehaviour
{
    public GameObject rechargePanel;
    public Gun gun;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rechargePanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                gun = other.gameObject.GetComponentInChildren<Gun>();
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
