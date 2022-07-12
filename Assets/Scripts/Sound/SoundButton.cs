using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (CoreGame.SoundOn)
        {            
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (!CoreGame.SoundOn)
        {            
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void SetSound()
    {
        
        if (CoreGame.SoundOn)
        {
            CoreGame.SoundOn = false;            
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(!CoreGame.SoundOn)
        {
            CoreGame.SoundOn = true;            
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        ControllerInfomation.instance.UpadateSoundStatus(CoreGame.SoundOn, CoreGame.MusicOn);
    }    
}
