using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;


namespace BrainHealthChecker
{
    public partial class ResultPage : View
    {
        public ResultPage()
        {
   
            InitializeComponent();
            NextStepButton.Text = "다음 할일";
            ExplanationLabel1.Text = "점수 계산중입니다";
            //startAni();
            update();
        }

        public void update()
        {
            int i = 0;
        // total score를 읽어서 화면에 표기 
            i = QuestionPage.g_totalScore;

            ScoreLabel2.Text = i.ToString();

            // total score가 6을 넘으면 치매 정밀 검사 필요 가능성 제시
            if (6 <= QuestionPage.g_totalScore) // 치매가능성
            {
                ExplanationLabel1.Text = "가까운 보건소/병원이나 치매안심센터 방문하시고";
                ExplanationLabel2.Text = "좀 더 정확한 치매검진을 받아 보시기 바랍니다";
                NextStepButton.Text = "우리동네 보건소 찾아보기";
            }
        // total score가 6을 안넘으면 치매 예방 안내
            else
            {
                ExplanationLabel1.Text = "앞으로도 운동과 외부 사회 활동을 유지하시고";
                ExplanationLabel2.Text = "치매예방수칙을 잘 실천하셔서 치매를 예방하세요";
                NextStepButton.Text = "치매예방수칙 바로가기";
            }

        }

        public void startAni()
        {
            Animation animation;
            float position = 0.0f;
            animation = new Animation(1200);
            position = 980.0f / 14.0f * QuestionPage.g_totalScore;
            animation.AnimateTo(AnimateView, "PositionX", 980);

            animation.ProgressNotification = 1f;
            animation.ProgressReached += (o, e) =>
            {
                update();
            };
            animation.Play();
        }

        private void GoToStartButton_Clicked(object sender, ClickedEventArgs e)
        {
 
            Window window;
            View view;
            window = NUIApplication.GetDefaultWindow();
            if (Scene1.g_pre_view != null)
            {
                window.Remove(Scene1.g_pre_view);
                Scene1.g_pre_view.Unparent();
                Scene1.g_pre_view.Dispose();
                Scene1.g_pre_view = null;
            }
  
            view = new Scene1Page();
            Scene1.g_pre_view = view;
            window.Add(view);
        }
    }
}
