using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public int item1 = 0; // score is 2 (Clover)
    public int item2 = 0; // score is 4 (Medicine)
    public int item3 = 0; // score is 6 (Monster EGG)
    public int item4 = 0; // score is 3 (OrangeMush)
    public int item5 = 0; // score is 5 (PurpleFlower)
    private int totalItemCount;
    public TMP_Text item1text;
    public TMP_Text item2text;
    public TMP_Text item3text;
    public Image slot1;
    public Image slot2;
    public Image slot3;

    public Image itemSlot1;
    public Image itemSlot2;
    public Image itemSlot3;

    public Sprite clover;
    public Sprite medicinePouch;
    public Sprite monsteregg;
    public Sprite orangeMush;
    public Sprite purpleFlower;
    public TMP_Text scoreText;
    public enum slots {slot1,slot2,slot3};
    slots currentslot = slots.slot1;

    List<KeyValuePair<slots, string>> inventory = new List<KeyValuePair<slots, string>>()
    {
        new KeyValuePair<slots, string>(slots.slot1,"empty"),
        new KeyValuePair<slots, string>(slots.slot2,"empty"),
        new KeyValuePair<slots, string>(slots.slot3,"empty")
    };

    // Start is called before the first frame update
    void Start()
    {
        totalItemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {


        CheckItemText(inventory[0].Value);
        CheckItemText1(inventory[1].Value);
        CheckItemText2(inventory[2].Value);

        totalItemCount = item1 + item2 + item3;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentslot == slots.slot1)
            {
                currentslot = slots.slot2;

            }else if(currentslot== slots.slot2) {
                
                currentslot= slots.slot3;
            }
            else
            {
                currentslot = slots.slot1;
            }
 
        }

        if(currentslot == slots.slot1)
        {
            item1text.fontStyle = FontStyles.Bold;
            slot1.gameObject.SetActive(true);
            slot2.gameObject.SetActive(false);
            slot3.gameObject.SetActive(false);
        }
        else
        {
            item1text.fontStyle = FontStyles.Normal;
        }
        if (currentslot == slots.slot2)
        {
            item2text.fontStyle = FontStyles.Bold;
            slot1.gameObject.SetActive(false);
            slot2.gameObject.SetActive(true);
            slot3.gameObject.SetActive(false);
        }
        else
        {
            item2text.fontStyle = FontStyles.Normal;
        }
        if (currentslot == slots.slot3)
        {
            item3text.fontStyle = FontStyles.Bold;
            slot1.gameObject.SetActive(false);
            slot2.gameObject.SetActive(false);
            slot3.gameObject.SetActive(true);
        }
        else
        {
            item3text.fontStyle = FontStyles.Normal;
        }

        // if(Input.GetKeyDown(KeyCode.E))
        // {
        //    
        //    scoreText.text = "score " + FinalScore();
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "item1" || collision.gameObject.tag == "item2" || collision.gameObject.tag == "item3" || collision.gameObject.tag == "item4" || collision.gameObject.tag == "item5")
            AddItemtoCurrentSlot(collision.gameObject);

    }

    public int GetTotalItemCount()
    {
        return totalItemCount;
    }

    public void AddItemtoCurrentSlot(GameObject item)
    {
        if(currentslot == slots.slot1) {
            if(inventory[0].Value == item.tag)
            {
               AddandDestoryvalue(item);
               
            }
            else
            {
                MakeZero(inventory[0].Value);
                inventory.RemoveAt(0);
                AddandDestoryvalue(item);
                inventory.Insert(0, new KeyValuePair<slots, string>(slots.slot1, item.tag));
                
                 

            }


        }

        if (currentslot == slots.slot2)
        {
            if (inventory[1].Value == item.tag)
            {
                AddandDestoryvalue(item);
            }
            else
            {
                MakeZero(inventory[1].Value);
                inventory.RemoveAt(1);
                AddandDestoryvalue(item);
                inventory.Insert(1, new KeyValuePair<slots, string>(slots.slot2, item.tag));
            }


        }

        if (currentslot == slots.slot3)
        {
            if (inventory[2].Value == item.tag)
            {
                AddandDestoryvalue(item);
            }
            else
            {
                MakeZero(inventory[2].Value);
                inventory.RemoveAt(2);
                AddandDestoryvalue(item);
                inventory.Insert(2, new KeyValuePair<slots, string>(slots.slot3, item.tag));
                
            }


        }

    }

    public void AddandDestoryvalue(GameObject item)
    {
        if (item.tag == "item1")
        {
            item1++;
            Destroy(item);
        }
        if (item.tag == "item2")
        {
            item2++;
            Destroy(item);
        }
        if (item.tag == "item3")
        {
            item3++;
            Destroy(item);
        }
        if (item.tag == "item4")
        {
            item4++;
            Destroy(item);
        }
        if (item.tag == "item5")
        {
            item5++;
            Destroy(item);
        }
    }

     public void MakeZero(string previousItem)
    {
        if(previousItem == "item1")
        {
            item1 = 0;
        }
        if (previousItem == "item2")
        {
            item2 = 0;
        }
         if(previousItem == "item3")
        {
            item3 = 0;
        }
        if (previousItem == "item4")
        {
            item4 = 0;
        }
        if (previousItem == "item5")
        {
            item5 = 0;
        }

    }

    public void CheckItemText(string text)
    {
        if(text == "item1")
        {
            item1text.text = "clover x " + item1;
            itemSlot1.sprite = clover;
        }
        if (text == "item2")
        {
            item1text.text = "medicinePouch x " + item2;
            itemSlot1.sprite = medicinePouch;
        }
        if (text == "item3")
        {
            item1text.text = "monsteregg x " + item3;
            itemSlot1.sprite = monsteregg;
        }
        if (text == "item4")
        {
            item1text.text = "orangeMush x " + item4;
            itemSlot1.sprite = orangeMush;
        }
        if (text == "item5")
        {
            item1text.text = "purpleFlower x " + item5;
            itemSlot1.sprite = purpleFlower;
        }
        if(text == "empty")
        {
            item1text.text = "empty";
            
        }
      

    }
    public void CheckItemText1(string text)
    {
        if (text == "item1")
        {
            item2text.text = "clover x " + item1;
            itemSlot2.sprite = clover;
        }
        if (text == "item2")
        {
            item2text.text = "medicinePouch x " + item2;
            itemSlot2.sprite = medicinePouch;
        }
        if (text == "item3")
        {
            item2text.text = "monsteregg x " + item3;
            itemSlot2.sprite = monsteregg;
        }
        if (text == "item4")
        {
            item2text.text = "orangeMush x " + item4;
            itemSlot2.sprite = orangeMush;
        }
        if (text == "item5")
        {
            item2text.text = "purpleFlower x " + item5;
            itemSlot2.sprite = purpleFlower;
        }
        if (text == "empty")
        {
            item2text.text = "empty";

        }

    }
    public void CheckItemText2(string text)
    {
        if (text == "item1")
        {
            item3text.text = "clover x " + item1;
            itemSlot3.sprite = clover;
        }
        if (text == "item2")
        {
            item3text.text = "medicinePouch x " + item2;
            itemSlot3.sprite = medicinePouch;
        }
        if (text == "item3")
        {
            item3text.text = "monsteregg x " + item3;
            itemSlot3.sprite = monsteregg;
        }
        if (text == "item4")
        {
            item3text.text = "orangeMush x " + item4;
            itemSlot3.sprite = orangeMush;
        }
        if (text == "item5")
        {
            item3text.text = "purpleFlower x " + item5;
            itemSlot3.sprite = purpleFlower;
        }
        if (text == "empty")
        {
            item3text.text = "empty";

        }

    }

    public float FinalScore()
    {
        float score = (item1 * 2) + (item2 * 4) + (item3 * 6) + (item4 * 3) + (item5 * 5);
        return score;
    }


}
