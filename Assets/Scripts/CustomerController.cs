using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject bookshelfController;
    public GameObject cashierObject;
    public GameObject exitTarget;
    public MoneyController moneyController;
    public TimerController timeController;
    public CustomerSpawner customerSpawner;

    public float moveDelay = 10;

    private Vector3 targetLocation = new Vector3(0, 0, 0);
    private bool foundTarget = false;
    private float timer = 0.0f;

    private float pickingBookDuration;
    private float buyingBookDuration = 0.5f;

    private customerState currentState;

    Animator anim;

    private GameObject temp;
    private BookshelvesController bookshelves;
    private Vector3 previousPosition;
    private float curSpeed;

    private float dist;

    public bool initialCharacter;

    public enum customerState
    {
        entering,
        browsing,
        buying,
        paying,
        leaving,
        remove,
        standing
    }
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        GameEvent.current.onCustomerSpawn += CustomerSpawned;
        bookshelves = bookshelfController.GetComponent<BookshelvesController>();

        pickingBookDuration = Random.Range(2, 10);

        currentState = customerState.entering;
        //if (initialCharacter)
        //{
        //    currentState = customerState.standing;
        //}
        //else {
        //    currentState = customerState.entering;
        //}



        temp = bookshelves.GetABookShelf();
    }

    void Update()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        timer += Time.deltaTime;

        anim.SetFloat("Speed_f", curSpeed / 4);

        var isClosed = timeController.IsClosingTime();

        switch (currentState){
            case (customerState.entering):
                if (timer >= moveDelay && temp != null)
                {
                    agent.SetDestination(temp.transform.position);

                    currentState = customerState.browsing;
                }
                if (isClosed) {
                    currentState = customerState.leaving;
                    if(temp != null)
                        temp.GetComponent<BookshelfController>().setOccupid(false);
                }
                break;
            case (customerState.browsing):
                dist = agent.remainingDistance;

                if (dist != Mathf.Infinity &&
                    agent.pathStatus == NavMeshPathStatus.PathComplete &&
                    agent.remainingDistance == 0)
                {
                    agent.transform.rotation = (temp.GetComponent<BookshelfController>().transform.rotation);
                    if (timer >= pickingBookDuration)
                    {
                        currentState = customerState.buying;
                        temp.GetComponent<BookshelfController>().setOccupid(false);
                    }
                    
                }
                else {
                    timer = 0.0f;
                }
                if (isClosed)
                {
                    currentState = customerState.leaving;
                    if (temp != null)
                        temp.GetComponent<BookshelfController>().setOccupid(false);
                }
                break;
            case (customerState.buying):
                agent.SetDestination(cashierObject.transform.position);

                currentState = customerState.paying;
                break;
            case (customerState.paying):
                dist = agent.remainingDistance;

                if (dist != Mathf.Infinity &&
                    agent.pathStatus == NavMeshPathStatus.PathComplete &&
                    agent.remainingDistance <= 0.2)
                {
                    if (timer >= buyingBookDuration) {
                        currentState = customerState.leaving;
                        moneyController.AddMoney(30);
                    }
                }
                else
                {
                    timer = 0.0f;
                }
                break;
            case (customerState.leaving):
                agent.SetDestination(exitTarget.transform.position);

                currentState = customerState.remove;
                break;
            case (customerState.remove):
                dist = agent.remainingDistance;


                if (dist != Mathf.Infinity &&
                    agent.pathStatus == NavMeshPathStatus.PathComplete &&
                    agent.remainingDistance <= 0.2)
                {
                    Destroy(this.gameObject);
                    customerSpawner.DecrementCustomerCount();
                }
                break;
            case (customerState.standing):
                break;
        }
    }



    private void CustomerSpawned() {
        foundTarget = true;
        //TODO GET FREE BOOKSHELF TO GO TO
    }

    public void CustomerStartAction()
    {
        Debug.Log("WOWOWOWOWW");
        gameObject.SetActive(true);
        return;
    }


}
