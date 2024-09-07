using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
    public void interactAble();
}
public class InteracterScript : MonoBehaviour
{
    public Transform interactorSoure;
    public float interactRange;
    public bool notInteracting;
    GameObject pickUpSprite;

    AudioSource PickUpAudio;
    private void Start()
    {
        pickUpSprite = GameObject.FindGameObjectWithTag("pickUpSprite");
        PickUpAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //casts a ray to look for a ray soures
        Ray r = new Ray(interactorSoure.position, interactorSoure.forward);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                    notInteracting = false;
                }
                else
                {
                    notInteracting = true;
                    pickUpSprite.SetActive(false);
                }

            }
        }
        else if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                pickUpSprite.SetActive(true);
                interactObj.interactAble();
                notInteracting=false;
            }
            else
            {
                notInteracting = true;
                pickUpSprite.SetActive(false);
            }
        }
        else
        {
            notInteracting = true;
            pickUpSprite.SetActive(false);
        }
    }
}
