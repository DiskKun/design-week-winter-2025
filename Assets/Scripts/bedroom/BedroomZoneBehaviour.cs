using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomZoneBehaviour : MonoBehaviour
{
    public BedroomObjectManager om;



    public Renderer roseRenderer;   // 0
    public Renderer toolkitRenderer;// 1
    public Renderer bedRenderer;    // 2
    public Renderer lampRenderer;   // 3
    public Renderer curtainRenderer;// 4
    public Renderer clockRenderer;  // 5
    public Renderer playmatRenderer;// 6

    public int seenState = 0;

    bool[] hasSeen = {false, false, false, false, false, false, false};
 



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (hasSeen[4] && hasSeen[1] && seenState == 0)
        {
            seenState = 1;
            om.SetState("lamp", 1);
        }
        if (hasSeen[3] && seenState == 1)
        {
            seenState = 2;
        }
        if (seenState == 2 && lampRenderer.isVisible)
        {

            if (om.GetState("curtain") == 2 && om.GetState("toolkit") == 2 && (om.GetState("clock") != 2))
            {
                
                om.SetState("lamp", 2);
                om.SetState("rose", 1);
                seenState = 3;

            }
            om.SetState("curtain", 1);
            om.SetState("toolkit", 1);
            om.SetState("clock", 1);
        }
        if (hasSeen[0] && seenState == 3)
        {
            seenState = 4;
        }
        if (seenState == 4 && roseRenderer.isVisible)
        {

            if (om.GetState("curtain") == 2 && om.GetState("toolkit") != 2 && (om.GetState("clock") == 2))
            {
                
                om.SetState("rose", 2);
                om.SetState("playmat", 1);
                seenState = 5;
            }
            om.SetState("curtain", 1);
            om.SetState("toolkit", 1);
            om.SetState("clock", 1);
        }

        if (hasSeen[6] && seenState == 5)
        {
            om.SetState("rose", 3);
            seenState = 6;
        }
        if (seenState == 6 && playmatRenderer.isVisible)
        {
            if (om.GetState("curtain") != 2 && om.GetState("toolkit") != 2 && (om.GetState("clock") == 2) && om.GetState("rose") == 2)
            {
                om.SetState("playmat", 2);
                om.SetState("bed", 1);
                seenState = 7;
            }
            om.SetState("curtain", 1);
            om.SetState("toolkit", 1);
            om.SetState("clock", 1);
            om.SetState("rose", 3);
        }

        if (hasSeen[2] && seenState == 7)
        {
            seenState = 8;
        }
        if (seenState == 8 && bedRenderer.isVisible)
        {
            if (om.GetState("curtain") != 2 && om.GetState("toolkit") == 2 && om.GetState("rose") == 2)
            {
                om.SetState("bed", 2);
                om.SetState("exitstar", 1);

                seenState = 9;
            }
            om.SetState("curtain", 1);
            om.SetState("toolkit", 1);
            om.SetState("clock", 1);
            om.SetState("rose", 3);
        }

    











        if (roseRenderer.isVisible && om.GetState("rose") != 0)
        {
            hasSeen[0] = true;
        }
        if (toolkitRenderer.isVisible && om.GetState("toolkit") != 0)
        {
            hasSeen[1] = true;
        }
        if (bedRenderer.isVisible && om.GetState("bed") != 0)
        {
            hasSeen[2] = true;
        }
        if (lampRenderer.isVisible && om.GetState("lamp") != 0)
        {
            hasSeen[3] = true;
        }
        if (curtainRenderer.isVisible && om.GetState("curtain") != 0)
        {
            hasSeen[4] = true;
        }
        if (clockRenderer.isVisible && om.GetState("clock") != 0)
        {
            hasSeen[5] = true;
        }
        if (playmatRenderer.isVisible && om.GetState("playmat") != 0)
        {
            hasSeen[6] = true;
        }
    }
}
