using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace AudioVideo
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

			Button audio = (Button)FindViewById(Resource.Id.Audio);
			Button video = (Button)FindViewById(Resource.Id.Video);

			audio.Click += GoToTheAudio;
			video.Click += GoToTheVideo;
        }

		void GoToTheAudio(object sender, System.EventArgs e)
		{
			Intent i = new Intent(this, typeof(AudioActivity));
			this.StartActivity(i);
		}
		void GoToTheVideo(object sender, System.EventArgs e)
		{
			Intent i = new Intent(this, typeof(VideoActivity));
			this.StartActivity(i);
		}
    }
}

