using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int item1;
    public int item2;
    public int item3;
    public TMP_Text item1text;
    public TMP_Text item2text;
    public TMP_Text item3text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        item1text.text = "item1 " + item1;
        item2text.text = "item2 " + item2;
        item3text.text = "item3 " + item3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "item1")
        {
            item1++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "item2")
        {
            item2++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "item3")
        {
            item3++;
            Destroy(collision.gameObject);
        }
    }

}
