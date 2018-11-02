using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AudioVideo
{
    [Activity(Label = "AudioVideo", MainLauncher = false)]
    class VideoActivity : Activity
    {

		VideoView video;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_video);

			video = (VideoView)FindViewById(Resource.Id.PlayVideo);

			string path = string.Format("android.resource://{0}/{1}", "AudioVideo.AudioVideo", Resource.Raw.Bunny);

			video.SetVideoPath(path);
			video.SetMediaController(new MediaController(this));
			video.RequestFocus();
			video.Start();

			Button backToMain = (Button)FindViewById(Resource.Id.BackMain);

			backToMain.Click += BackToMain;
        }

		private void BackToMain(object sender, System.EventArgs e)
		{
			video.Pause();
			Intent i = new Intent(this, typeof(MainActivity));
			this.StartActivity(i);
		}
    }
}