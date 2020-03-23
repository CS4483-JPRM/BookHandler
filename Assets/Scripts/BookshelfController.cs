using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfController : MonoBehaviour
{

    public bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOccupid(bool occ) {
        occupied = occ;
    }
}
