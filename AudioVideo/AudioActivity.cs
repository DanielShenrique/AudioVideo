using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AudioVideo
{
    [Activity(Label = "AudioVideo", MainLauncher = false)]
    class AudioActivity : Activity
    {
        private MediaPlayer mp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_audio);

            mp = MediaPlayer.Create(this, Resource.Raw.StarWars);

            Button startAudio = (Button)FindViewById(Resource.Id.StartAudio);
            Button pauseAudio = (Button)FindViewById(Resource.Id.StopAudio);

            startAudio.Click += ButtonPlay;
            pauseAudio.Click += ButtonStop;
        }

        private void ButtonPlay(object sender, System.EventArgs e)
        {
            if (mp != null && !mp.IsPlaying)
            {
                mp = MediaPlayer.Create(this, Resource.Raw.StarWars);
                mp.Start();
            }
        }
        private void ButtonStop(object sender, System.EventArgs e)
        {
            MPManager(1);
        }

        #region States
        protected override void OnPause()
        {
            base.OnPause();

            MPManager(0);
        }
        protected override void OnStop()
        {
            base.OnStop();

            MPManager(1);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            MPManager(2);
        }
        #endregion

        private void MPManager(int state)
        {
            if (mp != null && mp.IsPlaying)
            {
                switch (state)
                {
                    case 0: mp.Pause(); break;
                    case 1: mp.Stop(); break;
                    case 2: mp.Release(); break;
                }
            }
        }
    }
}