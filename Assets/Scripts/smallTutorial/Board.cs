using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Input Settings: ")]
    [SerializeField] private LayerMask boxesLayerMask;
    [SerializeField] private float touchRadius;

    [Header("Mark Sprites: ")]
    [SerializeField] private Sprite spriteX;
    [SerializeField] private Sprite spriteO;

    [Header("Mark Colors: ")]
    [SerializeField] private Color colorX;
    [SerializeField] private Color colorO;

    public Mark[] marks;
    private Camera cam;
    private Mark currentMark;

    private void HitBox(Box box)
    {
        if (!box.isMarked)
        {
            marks[box.index] = currentMark;
            box.SetAsMarked(GetSprite(), currentMark);
        }

    }

    private Color GetColor()
    {
        return (currentMark == Mark.X) ? colorX : colorO;
    }
    private Sprite GetSprite()
    {
        return (currentMark == Mark.X) ? spriteX : spriteO;
    }

    private void SwitchPlayer()
    {
        currentMark = (currentMark == Mark.X) ? Mark.O : Mark.X;
    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        currentMark = Mark.X;
        marks = new Mark[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapCircle(touchPosition, touchRadius, boxesLayerMask);
            if (hit)
            {
                Debug.Log("Got hit!");
                HitBox(hit.GetComponent<Box>());
                SwitchPlayer();
            }

        }
    }
}
