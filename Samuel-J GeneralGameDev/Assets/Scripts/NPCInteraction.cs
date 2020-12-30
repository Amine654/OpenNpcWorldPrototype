using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField]
    private bool RequestReceived = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RequestReceived == true)
        {
            RequestHandler();
        }
        else
        {
            InteractionInitiationHandler();
        }
    }

    void RequestHandler()
    {
        //Don't know how request will be sent that's why I am just checking with gameObject.transform
        if(gameObject.transform.tag == "Player")
        {
            PlayerRequestHandler();
        }
        else if(gameObject.transform.tag == "NPC")
        {
            NPCRequestHandler();
        }
    }

    //This is checking for request with colliders and on trigger because I don't know how 
    //request will be sent
    private void OnTriggerEnter(Collider other)
    {
        if(RequestReceived == true)
        {
            if(other.tag == "Player")
            {
                PlayerRequestHandler();
            }
            else if(other.tag == "NPC")
            {
                NPCRequestHandler();
            }
        }
        else
        {
            InteractionInitiationHandler();
        }
    }

    string PlayerRequestHandler()
    {
        return "Hi";
    }

    void NPCRequestHandler()
    {
        int ReplyNum = Random.Range(0, 2);

        //Don't want to accept
        if(ReplyNum == 0)
        {
            return;
        }
        //Wan't to accept
        else if(ReplyNum == 1)
        {
            //NPC receives greeting
            //NPC replies hi
            //receive NPC reply
            //if reply contains stop signal
            //end convo
            //else
            //Determine whether to continue convo with random.range again
            //if no
            //end convo logic
            //if yes
            //continue convo
        }
    }

    void InteractionInitiationHandler()
    {
        transform.Translate(new Vector3(Random.Range(-50, 51), 0, Random.Range(-50, 51)));
        //Again still don't know how interaction will be initiated
        int InitNum = Random.Range(0, 2);
        //Don't want to initiate interaction
        if(InitNum == 0)
        {
            return;
        }
        //Wan't to initiate interaction
        else if(InitNum == 1)
        {
            //send interaction request
            //if accepted
            //Engage in convo
            //else
            //return
        }
    }
}
