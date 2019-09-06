using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public static Dictionary<string, AudioClip> audioDataBase;
    //public List<AudioClip> audioTable;
    //// Start is called before the first frame update
    public AudioClip PenguinShout;
    public AudioClip SmashPaw;
    private void Awake()
    {
        //AudioClip[] temp = Resources.FindObjectsOfTypeAll(typeof(AudioClip)) as AudioClip[];

        //foreach (AudioClip audioItem in temp)
        //{
        //    audioDataBase.Add(audioItem.name, audioItem);
        //    audioTable.Add(audioItem);
        //}

    }

}
