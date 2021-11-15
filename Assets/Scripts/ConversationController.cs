using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    public float delay = 0.1f;
    private string currentText = "";
    private string fullText;

    public void showText(string msg)
    {
        this.activate();
        this.StopAllCoroutines();

        fullText = msg;
        StartCoroutine(runShowText());
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    IEnumerator runShowText()
    {
        for(int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(4);
        this.deactivate();
    }
}
