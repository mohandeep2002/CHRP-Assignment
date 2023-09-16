using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    [Header("Bools")]
    public bool isGlovesThere = false;
    public bool isFaceSheildThere = false;

    [Header("Buttons")]
    public Button glovesButton;
    public Button faceShieldButton;

    [Header("Panels")]
    public GameObject initialPanel;
    public GameObject glovesPanel;
    public GameObject faceShieldPanel;

    [Header("Game Objcts")]
    public GameObject greenButton;
    public GameObject switchOnButton;
    public GameObject rodInteractable;
    public GameObject rodPlacement;

    public GameObject sparks;

    public float delayInSeconds;

    public Vector3 initialTransform;
    public GameObject[] ironPlates;


    private void Start()
    {
        initialTransform = rodInteractable.transform.position;
    }

    private void Update()
    {
        if (isGlovesThere && isFaceSheildThere)
        {
            SkipButtonClicked();
        }
    }

    #region ButtonClickFunctions
    public void SkipButtonClicked()
    {
        initialPanel.SetActive(false);
        greenButton.GetComponent<XRSimpleInteractable>().enabled = true;
    }

    public void FaceSheildButtonClicked()
    {
        isFaceSheildThere = true;
    }

    public void GlovesButtonClicked()
    {
        isGlovesThere = true;
    }
    #endregion

    public bool CheckInteractable()
    {
        Debug.Log("Checking bools");
        if (!isGlovesThere)
        {
            glovesPanel.SetActive(true);
            return false;
        }
        if (!isFaceSheildThere)
        {
            faceShieldPanel.SetActive(true);
            return false;
        }
        return true;
    }

    public void GreenButtonPushed()
    {
        StartCoroutine(DelayGreenButton());
    }

    IEnumerator DelayGreenButton()
    {
        yield return new WaitForSeconds(delayInSeconds);
        greenButton.transform.localPosition = Vector3.Lerp(greenButton.transform.position, new Vector3(-8.84360027f, 1.06258702f, 2.13439202f), 2f);
        OnGreenButtonSwitchedOn();
    }

    public void SwitchOnPushed()
    {
        StartCoroutine(DelaySwitchPush(switchOnButton));
    }

    IEnumerator DelaySwitchPush(GameObject gameObject)
    {
        yield return new WaitForSeconds(delayInSeconds);
        gameObject.GetComponent<Animator>().enabled = true;
        OnSwitchButtonOn();
    }


    #region Actions
    public void OnGreenButtonSwitchedOn()
    {
        switchOnButton.GetComponent<XRSimpleInteractable>().enabled = true;
    }

    public void OnSwitchButtonOn()
    {
        rodInteractable.GetComponent<XRGrabInteractable>().enabled = true;
        rodPlacement.SetActive(true);
        for (int i = 0; i < ironPlates.Length; i++)
        {
            ironPlates[i].GetComponent<IronPlatesRotation>().enabled = true;
        }
    }

    public void ResetTransforms()
    {
        rodInteractable.GetComponent<XRGrabInteractable>().enabled = false;
        rodInteractable.transform.SetPositionAndRotation(initialTransform, Quaternion.Euler(0, -90, -90));
    }
    #endregion
}
