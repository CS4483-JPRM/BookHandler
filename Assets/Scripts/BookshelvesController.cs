using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelvesController : MonoBehaviour
{
    private GameObject[] bookshelves;
    private BookshelfController[] bookshelfInstances;
    private List<int> occupied;

    // Start is called before the first frame update
    void Start()
    {
        bookshelves = GameObject.FindGameObjectsWithTag("Bookshelf");
        occupied = new List<int>();

        
        //Debug.Log($"Instances Found {bookshelfInstances.Length}");


        Debug.Log(bookshelves[0].transform.position.x);
        Debug.Log(bookshelves[0].transform.position.y);
        Debug.Log(bookshelves[0].transform.position.z);
        Debug.Log("----");
        Debug.Log(bookshelves.Length);
    }

    // Update is called once per frame
    void Update()
    {
        bookshelfInstances = FindObjectsOfType(typeof(BookshelfController)) as BookshelfController[];
    }

    public Vector3? GetBookShelfPos()
    {
        if (bookshelves.Length <= 0 || bookshelves.Length == occupied.Count) {
            Debug.Log("Couldn't find any");
            Debug.Log(occupied.Count);
            return null;
        }
        try
        {
            int x = -1;
            while (occupied.IndexOf(x) != -1)
            {
                x = Random.Range(0, bookshelves.Length);
                Debug.Log(x);
            }
            Debug.Log("oo");
            occupied.Add(x);

            return bookshelves[x].transform.position;
        }
        catch {
            return null;
        }
    }

    public GameObject GetABookShelf()
    {

        var unoccupied = new List<BookshelfController>();
        foreach (var obj in bookshelfInstances) {
            if (!obj.occupied) {
                unoccupied.Add(obj);
            }
        }
        Debug.Log($"Unoccupied {unoccupied.Count}");

        if (unoccupied.Count <= 0)
        {
            Debug.Log("Couldn't find any");
            Debug.Log(occupied.Count);
            return null;
        }
        try
        {
            var bookObj = unoccupied[Random.Range(0, unoccupied.Count)];
            Debug.Log("OCCUPYING");
            bookObj.setOccupid(true);

            return bookObj.gameObject;
        }
        catch
        {
            return null;
        }
    }
}
