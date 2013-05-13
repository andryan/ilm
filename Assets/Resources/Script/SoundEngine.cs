using UnityEngine;
using System.Collections;
//@ Author: Kaizer
[RequireComponent (typeof(AudioSource))]
public class SoundEngine : MonoBehaviour 
{
	//@ Kaizer: Data
	private AudioClip MySound = null;
	private float MasterVolume = 0f;
	
	private void Start () 
	{
		MasterVolume = 1f;
	}
	public void PlayBGM(string Directory)
	{
		MySound = Resources.Load ("Sounds/"+Directory) as AudioClip;
		
		audio.clip = MySound;
		audio.loop = true;
		audio.Play ();	
	}
	public void StopBGM()
	{
		audio.Stop ();		
	}
	public void PlaySFX(string Directory)
	{
		MySound = Resources.Load ("Sounds/"+Directory) as AudioClip;
		audio.PlayOneShot(MySound);
	}
	public void OnMasterVolume()
	{
		MasterVolume = 1f;
		audio.volume = MasterVolume;
	}
	public void OffMasterVolume()
	{
		MasterVolume = 0f;
		audio.volume = MasterVolume;
	}
}
