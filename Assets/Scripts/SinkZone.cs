using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;
public class SinkZone : MonoBehaviour
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
            objectManager.SetState("sink", 2);
            if (zoneBehaviour.seenState == 2)
            {
                zoneBehaviour.seenState = 3;
            }
            if (zoneBehaviour.seenState == 9)
            {
                zoneBehaviour.seenState = 10;
            }
            
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (zoneBehaviour.seenState >= 2)
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
