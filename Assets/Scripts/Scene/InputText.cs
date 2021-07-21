using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update
    public static InputText instance;
    private InputText()
    {
        instance = this;
    }
    public static InputText Instance
    {
        get
        {
            return instance;
        }
    }
    Text inputtext;
    void Start()
    {
        inputtext = gameObject.GetComponent<Text>();
        inputtext.text = ("nhấn mũi tên hướng lên để nhảy");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputtext.text = ("nhấn mũi tên hướng xuống để cúi");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputtext.text = ("nhấn z  để đánh");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputtext.text = ("nhấn x  để bắn");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            inputtext.text = ("nhấn v để ném lựu đạn");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputtext.text = ("nhấn mũi tên hai bên để di chuyển");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputtext.text = ("di chuyển tiếp để qua màn");
        }
    }
}
