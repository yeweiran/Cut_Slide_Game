using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("BGMPlayer").GetComponent<SoundManager>();
            }
            return _instance;
        }
    }

    public IEnumerator LoadAudio (string name, float Volume, float Pitch, float time, float delay, bool isloop)
	{
		string url = @Application.streamingAssetsPath + "\\SFX\\" + name;
		WWW www = new WWW ("file://" + url);
		yield return www;
		AudioClip clip = www.GetAudioClip ();
		GameObject audio = new GameObject ("Audio");
		AudioSource source = audio.AddComponent<AudioSource> ();
		source.loop = isloop;
		source.clip = clip;
		source.volume = Volume;
		source.pitch = Pitch;
		yield return new WaitForSeconds (delay);
		source.Play ();	
		yield return new WaitForSeconds (time);
		Destroy (audio);
	}
}
