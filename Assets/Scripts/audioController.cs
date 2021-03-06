﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DemoChapter;


public class audioController : MonoBehaviour {

    public AudioSource BGM;
    public Slider sliderBGM;


    public void PlayMusic(AudioSource bgm,string musicPath)
    {
        if (musicPath == "")
        {
            return;
        }
        bgm.clip = Resources.Load(musicPath, typeof(AudioClip)) as AudioClip;
        bgm.Play();
        return;
    }

    private int bgmNumPrefix = 1;
    private int bgmNumMax = 3;

    private void nextBgm() {
        int next = (int)(Random.value * 1000) % (bgmNumMax-1) + 1;
        bgmNumPrefix = (bgmNumPrefix - 1 + next) % 3 + 1;
        return;
    }

    // Use this for initialization
    private GameObject title;
    void Start () {
        BGM.volume = sliderBGM.value;

    }

   
    
	// Update is called once per frame
	void Update () {
        BGM.volume = sliderBGM.value;
#pragma warning disable CS0618 // 类型或成员已过时
        if (BGM.isPlaying == false && title.gameObject.active == true) {
#pragma warning restore CS0618 // 类型或成员已过时
            nextBgm();              
            PlayMusic(BGM,"Assets/BGM/" + bgmNumPrefix + ".mp3");
        }
        if (title.gameObject.active == false) BGM.Stop();
    }
}
