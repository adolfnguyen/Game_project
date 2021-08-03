using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    private void OnEnable()
    {

        if (CoreGame.MusicOn)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (!CoreGame.MusicOn)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusic()
    {

        if (CoreGame.MusicOn)
        {
            CoreGame.MusicOn = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            SoundManager.instance.SetMusic(CoreGame.CurMusic, true, false);
        }
        else if (!CoreGame.MusicOn)
        {
            CoreGame.MusicOn = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            SoundManager.instance.SetMusic(CoreGame.CurMusic, true, true);
        }
        ControllerInfomation.instance.UpadateSoundStatus(CoreGame.SoundOn, CoreGame.MusicOn);
    }
}
