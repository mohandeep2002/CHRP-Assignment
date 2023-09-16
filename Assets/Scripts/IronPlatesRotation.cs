using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPlatesRotation : MonoBehaviour
{
    public float rotationSped = 30.0f;
    public GameController gameController;

    private void Update()
    {
        float rotationAngle = rotationSped * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0, 0, rotationSped);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Rod"))
        {
            Debug.Log("Rod came here into iron");
            gameController.sparks.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Rod"))
        {
            Debug.Log("Rod went from iron");
            gameController.sparks.SetActive(false);
        }
    }
}
