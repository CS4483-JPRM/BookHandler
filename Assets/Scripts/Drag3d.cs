using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag3d : MonoBehaviour
{
    #region Private Variables
    float ZPosition;
    float YPosition;
    Vector3 OffSet;
    bool Dragging;
    #endregion

    #region Inspector Variables
    public Camera MainCamera;
    [Space]
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
        YPosition = MainCamera.WorldToScreenPoint(transform.position).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dragging) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(position+ new Vector3(OffSet.x,OffSet.y));//position + new Vector3(OffSet.x, 0,OffSet.y)
        }
    }

    private void OnMouseDown()
    {
        if (!Dragging) {
            BeginDrag();
        }
    }

    private void OnMouseUp()
    {
        EndDrag();
    }
    #endregion

    #region User Interface
    public void BeginDrag() {
        OnBeginDrag.Invoke();
        Dragging = true;
        OffSet = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void EndDrag() {
        OnEndDrag.Invoke();
        Dragging = false;
    }
    #endregion
}
