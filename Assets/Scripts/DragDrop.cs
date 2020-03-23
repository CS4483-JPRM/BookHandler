using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject objectDragged;
    public Camera camera;
    public float costValue;
    public Text costTxt;
    public AudioSource errorNoise;

    private int hitLayers;

    private GameObject obj;
    private MoneyController moneyController;


    private Vector3 OffMapVector = new Vector3(-99, -99, 99);
    private void Awake()
    {
        moneyController = FindObjectOfType<MoneyController>();
        hitLayers = LayerMask.NameToLayer("BuildFloor");
        Debug.Log("THIS IS THE HIT LAYER"+hitLayers);
    }

    public void Start()
    {
        costTxt.text = $"${costValue}";
    }

    public void OnBeginDrag(PointerEventData eventData) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << hitLayers) && (moneyController.GetMoney() - costValue) >= 0)
        {
            Transform objectHit = hit.transform;

            obj = Instantiate(objectDragged, objectHit.position, Quaternion.identity);
        }
        else if (Physics.Raycast(ray, out hit) && (moneyController.GetMoney() - costValue) >= 0)
        {
            obj = Instantiate(objectDragged, new Vector3(-99, -99, 99), Quaternion.identity);
        }
        else {
            errorNoise.Play();
        }

    }

    public void OnDrag(PointerEventData eventData) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << hitLayers) && ( moneyController.GetMoney() - costValue) >= 0)
        {
            obj.transform.position = hit.point;
            Debug.Log(hit.collider.gameObject.name + " (" + hit.collider.tag + ") ");
        }
        else if (Physics.Raycast(ray, out hit) && ( moneyController.GetMoney() - costValue) >= 0)
        {
            obj.transform.position = OffMapVector;
        }
        else {
            Debug.Log("Hurr Durr idk what is going on");
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << hitLayers))
        {
            Destroy(obj);
            errorNoise.Play();
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << hitLayers) && (moneyController.GetMoney() - costValue) >= 0)
        {
            FindObjectOfType<MoneyController>().RemoveMoney(costValue);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
