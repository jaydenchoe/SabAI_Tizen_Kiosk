using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BrainHealthChecker
{
    public partial class VideoPopup : View
    {
        private VideoPlayer videoPlayer;
        public VideoPopup()
        {
            InitializeComponent();
            ppp();
        }
        public void ppp()
        {
            videoPlayer = new VideoPlayer(playerView);
            if (videoPlayer != null)
            {
                SetAsyncSourceAndPlay();
            }
        }
        public async void SetAsyncSourceAndPlay()
        {
            videoPlayer.SetSource(new Tizen.Multimedia.MediaUriSource(
              Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/video/sample.mp4"));
            await videoPlayer.PrepareAsync();
            await videoPlayer.SetPlayPositionAsync(0, true);

            playerView.Play();
        }
        private void playStopButton_Clicked(object sender, ClickedEventArgs e)
        {
            this.Unparent();
            this.Dispose();
            playerView.Stop();
            playerView.Unparent();
            playerView.Dispose();
            playerView = null;
     
        }
    }

    public class VideoPlayer : Tizen.Multimedia.Player
    {
        public VideoPlayer() : base()
        {
            Initialize();
        }

        public VideoPlayer(IntPtr ptr) : base(ptr, null)
        {
            Initialize();
        }

        public VideoPlayer(VideoView videoView) : base((new SafeNativePlayerHandle(videoView)).DangerousGetHandle(), null)
        {
            Initialize();
        }
    }
}
