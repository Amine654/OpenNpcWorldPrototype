using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject Npc;

    public string NpcTextBox;
    private bool Conversation;

    private NpcInteraction npcInteraction;

    public bool startConversation = false;
    private bool continueConversation = false;
    private bool decidedStart = false;
    private bool decidedConitnue = false;

    int acceptReq;

    // Start is called before the first frame update
    void Start()
    {
        npcInteraction = Npc.GetComponent<NpcInteraction>();
        Conversation = true;
        StartCoroutine(ConvoRoutine());
    }

    IEnumerator ConvoRoutine()
    {
        while (Conversation)
        {
            float dist = Vector3.Distance(Npc.transform.position, transform.position);

            if (dist < 2f)
            {
                decidedStart = true;
                if (npcInteraction.startConversation)
                {
                    ReceiveConvoRequestHandler();
                }
                else
                {
                    InitiateConvo();
                }
            }
            yield return new WaitForSeconds(2.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (decidedStart == false)
        {
            acceptReq = Random.Range(0, 2);
            DecideStartingConvo();
        }
        if (decidedConitnue == false)
        {
            DecideContinueConvo();
        }

        if(npcInteraction.startConversation == false && startConversation == false && decidedStart == true)
        {
            startConversation = true;
        }
    }

    void ReceiveConvoRequestHandler()
    {
        //Won't accept request
        if (acceptReq == 0)
        {
            StartCoroutine(ResponseCoolDownRoutine());
            if (npcInteraction.NpcTextBox == "Hi")
            {
                NpcTextBox = "Sorry can't talk now, I am busy";
                Debug.Log("N2 : Sorry can't talk now, I am busy");
                Conversation = false;
            }
        }
        //Will accept request
        else if (acceptReq == 1)
        {
            if (npcInteraction.NpcTextBox == "Hi")
            {
                StartCoroutine(ResponseCoolDownRoutine());
                NpcTextBox = "Hi";
                Debug.Log("N2 : Hi");
            }
            if (npcInteraction.NpcTextBox == "I am Jack, Good Morning")
            {
                decidedConitnue = true;
                if (continueConversation)
                {
                    NpcTextBox = "Hi Jack, Morning. I am Micheal";
                    Debug.Log("N2 : Hi Jack, Morning. I am Micheal");
                }
                else
                {
                    NpcTextBox = "Hi Jack, Morning. I am Micheal. I am busy I can't talk now";
                    Debug.Log("N2 : Hi Jack, Morning. I am Micheal. I am busy I can't talk now");
                    Conversation = false;
                }

            }
            if (npcInteraction.NpcTextBox == "Hi Micheal, nice to meet you. Well see you around")
            {
                Debug.Log("Alright");
                Conversation = false;
            }

        }
    }

    IEnumerator ResponseCoolDownRoutine()
    {
        yield return new WaitForSeconds(1.2f);
    }

    void DecideStartingConvo()
    {
        int startConvo = Random.Range(0, 2);

        //Will not start convo
        if (startConvo == 0)
        {
            startConversation = false;
        }
        //Will start convo
        else if (startConvo == 1)
        {
            startConversation = true;
        }
    }

    void DecideContinueConvo()
    {
        int continueConvo = Random.Range(0, 2);

        //Will not start convo
        if (continueConvo == 0)
        {
            continueConversation = false;
        }
        //Will start convo
        else if (continueConvo == 1)
        {
            continueConversation = true;
        }
    }

    void InitiateConvo()
    {
        if (startConversation == true)
        {
            NpcTextBox = "Hi";
            Debug.Log("N1 : Hi");
            if (npcInteraction.NpcTextBox == "Hi")
            {
                NpcTextBox = "I am Jack, Good Morning";
                Debug.Log("N1 : I am Jack, Good Morning");
            }
            else if (npcInteraction.NpcTextBox == "Sorry can't talk now, I am busy")
            {
                Debug.Log("N1: Ok");
                Conversation = false;
            }

            if (npcInteraction.NpcTextBox == "Hi Jack, Morning. I am Micheal")
            {
                NpcTextBox = "Hi Micheal, nice to meet you. Well see you around";
                Debug.Log("N1 : Hi Micheal, nice to meet you. Well see you around");
                Conversation = false;
            }
            else if (npcInteraction.NpcTextBox == "Hi Jack, Morning. I am Micheal. I am busy I can't talk now")
            {
                Debug.Log("N1 : Ok");
                Conversation = false;
            }
        }
    }
}

