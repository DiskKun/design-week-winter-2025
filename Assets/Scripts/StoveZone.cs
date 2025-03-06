using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoveZone : MonoBehaviour
{
    public ObjectManager objectManager;
    public ZoneBehaviour zoneBehaviour;
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
            objectManager.SetState("stove", 2);
            if (zoneBehaviour.seenState == 6)
            {
                zoneBehaviour.seenState = 7;
            }
            if (zoneBehaviour.seenState == 11)
            {
                zoneBehaviour.seenState = 12;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (zoneBehaviour.seenState >= 4)
        {
            interactMessageText.text = "Press E to interact with " + objectName;
            interactMessage.SetActive(true);
            interact = true;
        }

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
