using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.tag = "Untagged";
            other.gameObject.AddComponent<Money>();
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;


            CollectedManager.instance.StackMoney(other.gameObject,CollectedManager.instance.collectedMoney.Count-1);
        }
    }
}
