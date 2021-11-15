using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InventoryController : MonoBehaviour
{
    public GameObject itemBtn;
    public GameObject player;
    public Transform inventoryAttachPoint;
    public AudioSource itemPickedSound;
    public GameObject conversationController;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void pickUpItem(GameObject obj)
    {
        closeInventory();
        addItemToInventory(obj);
        obj.SetActive(false);
        itemPickedSound.Play();
        conversationController.GetComponent<ConversationController>().showText(Constants.ITEM_ADDED);
    }
    public void interactWithItem(GameObject obj)
    {
        transform.position = inventoryAttachPoint.position;
        transform.rotation = inventoryAttachPoint.transform.rotation;
        spawnButtonsOnCanvas();
        gameObject.SetActive(true);
    }

    public void closeInventory()
    {
        gameObject.SetActive(false);
    }

    public void removeItem(GameObject item)
    {
        Destroy(item);
        closeInventory();
    }

    private void addItemToInventory(GameObject item)
    {
        GameObject newButton= Instantiate(itemBtn, new Vector3(0,0,0), Quaternion.identity);
        newButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = seperateWords(item.name);
        newButton.transform.SetParent(transform.GetChild(0).transform, false);

        newButton.name = item.name + "Btn";
        newButton.tag = item.name + "Btn";
    }

    private string seperateWords(string str)
    {
        return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + m.Value[1]);
    }

    private void spawnButtonsOnCanvas()
    {
        Vector3[] v = new Vector3[4];
        transform.GetChild(0).GetComponent<RectTransform>().GetLocalCorners(v);

        float height = itemBtn.GetComponent<RectTransform>().rect.height;
        float width = itemBtn.GetComponent<RectTransform>().rect.width;        int children = transform.GetChild(0).childCount;
        int buttonCount = 0;

        for (int i = 2; i < children; i++)
        {
            float posX = v[1].x + (width / 1.6f);
            float posY = v[1].y - (height + ((i - 2) * 30)) ;
            transform.GetChild(0).transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
            buttonCount++;
        }
    }
}
