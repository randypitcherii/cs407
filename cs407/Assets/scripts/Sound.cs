using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sound
{
    /**
     * Plays the sound with the given file name.
     *
     * @param gameObject    The game object to attach to.
     * @param fileName      The name of the sound to play.
     */
    public static void playSound(GameObject gameObject, string fileName)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>(); //used to play sounds
        
        //check if an audio source was found
        if (audio == null)  //and audio source was not found
        {
            //create a new audio source attached to the player
            gameObject.AddComponent<AudioSource>();
        }   //end if

        //stop any previous sound
        audio.Stop();

        //switch to the new sound
        audio.clip = (AudioClip)Resources.Load("Sounds/" + fileName);

        //play the sound
        audio.Play();
    }   //end of playSound method
}   //end of Sound class