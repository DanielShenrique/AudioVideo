using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AudioVideo
{
    [Activity(Label = "AudioVideo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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

