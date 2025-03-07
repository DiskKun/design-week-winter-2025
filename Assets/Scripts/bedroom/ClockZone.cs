using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockZone : MonoBehaviour
{
    public BedroomObjectManager om;
    public BedroomZoneBehaviour zoneBehaviour;
    public GameObject interactMessage;
    public string objectName;

    bool interact = false;
    TextMeshProUGUI interactMessageText;

    // Start is called before the first frame update
    void Start()
    {
        interactMessageText = interactMessage.GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {


        if (interact && Input.GetKeyDown(KeyCode.E))
        {
            om.SetState("clock", 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        interactMessageText.text = "Press E to interact with " + objectName;
        interactMessage.SetActive(true);
        interact = true;

    }

    void OnTriggerStay2D(Collider2D collision)
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactMessage.SetActive(false);
        interact = false;
    }
}
