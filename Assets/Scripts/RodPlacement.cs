using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodPlacement : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag.Equals("Rod"))
        {
            Debug.Log("Came inside");
            if (gameController.CheckInteractable())
            {
                gameController.rodPlacement.SetActive(false);
                for (int i = 0; i < gameController.ironPlates.Length; i++)
                {
                    gameController.ironPlates[i].GetComponent<BoxCollider>().enabled = true;
                }
                return;
            }
            else
            {
                gameController.ResetTransforms();
                gameController.sparks.SetActive(true);
                StartCoroutine(StopSparks());
            }
        }
    }

    IEnumerator StopSparks()
    {
        yield return new WaitForSeconds(4f);
        gameController.sparks.SetActive(false);
    }
}
