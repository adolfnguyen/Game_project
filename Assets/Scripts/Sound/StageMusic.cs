using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public string stageMusic;
    void Start()
    {
        SoundManager.instance.SetMusic(stageMusic, true, true);
        CoreGame.CurMusic = stageMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
