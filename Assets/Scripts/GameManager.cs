using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    GameObject[,] grid = new GameObject[6, 6];
    GameObject[] cardLayout = new GameObject[12];

    public GameObject cards;

    GameObject obj;
    void Start()
    {
        cardLayout = new GameObject[]
        {
            Create("back", 0, 0), Create("back", 1, 0), Create("back", 2, 0), Create("back", 3, 0),
            Create("back", 0, 1), Create("back", 1, 1), Create("back", 2, 1), Create("back", 3, 1),
            Create("back", 0, 2), Create("back", 1, 2), Create("back", 2, 2), Create("back", 3, 2),
        };
    }

    GameObject Create(string name, int x, int y)
    {
        obj = Instantiate(cards, new Vector2(x, y), Quaternion.identity);
        Cards c = obj.GetComponent<Cards>();
        c.name = name;
        c.SetXPosition(x);
        c.SetYPosition(y);
        c.Activate();
        return obj;
    }
    public void OnClick(InputValue value)
    {
        if (value.isPressed)
        {            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                print("hit");
            }
        }
    }
}
