using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Door : MonoBehaviour
{
    int leveLoad = 1;
    public UIManager uI;
    // Start is called before the first frame update
    void Start()
    {
        uI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        uI.inputText.text = ("nhấn mũi tên hướng lên để nhảy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            uI.inputText.text = ("nhấn mũi tên hướng xuống để cúi");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            uI.inputText.text = ("nhấn z  để đánh");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            uI.inputText.text = ("nhấn x  để bắn");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            uI.inputText.text = ("nhấn v để ném lựu đạn");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            uI.inputText.text = ("nhấn mũi tên hai bên để di chuyển");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            uI.inputText.text = ("di chuyển tiếp để qua màn");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(leveLoad);

        }
    }
}
