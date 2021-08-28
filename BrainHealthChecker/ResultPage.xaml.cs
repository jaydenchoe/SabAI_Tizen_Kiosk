using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;


namespace BrainHealthChecker
{

    public partial class ResultPage : View
    {
        private Button m_closeBtn = null;
        private ScrollableBase m_scrollableBase = null;
        private View[] m_items = null;
        private string[] m_dementiaInstituteList =
        {
            "가평군치매안심센터, 경기 가평군 가평읍 가화로 155-18, 031-580-2849",
            "고양시덕양구치매안심센터, 경기 고양시 덕양구 마상로126번길 73, 031-8075-4800",
            "고양시일산동구치매안심센터, 기도 고양시 일산동구 중앙로 1228. 031-8075-4850",
            "과천시치매안심센터, 경기 과천시 관문로 69, 02-2150-3572",
            "광명시치매안심센터, 경기 광명시 오리로 613, 02-2680-6546",
            "구리시치매안심센터, 경기 구리시 건원대로34번길 84, 031-550-8313",
            "군포시치매안심센터, 경기 군포시 군포로 522. 031-389-4989",
            "김포시치매안심센터, 경기 김포시 사우중로73번길 52, 031-980-5453",
            "남양주시치매안심센터. 경기도 남양주시 와부읍 덕소로71번길 5, 031-590-8700",
            "동두천시치매안심센터, 경기 동두천시 거북마루로 49, 031-860-3395",
            "부천시소사구치매안심센터, 경기 부천시 양지로 134, 032-625-9871",
            "성남시분당구치매안심센터, 경기도 성남시 분당구 내정로94, 031-729-4053",
            "수원시권선구치매안심센터, 경기 수원시 권선구 탑동 910, 031-228-6969",
            "시흥시치매안심센터, 경기도 시흥시 호현로 55, 031-310-5857",
            "안산시단원구보건소치매안심센터, 경기도 안산시 단원구 화랑로 250, 031-481-6541",
            "안성시치매안심센터, 경기 안성시 강변로74번길 18, 031-678-3002",
            "안양시치매안심센터, 경기 안양시 동안구 관악대로 375, 031-8045-6804",
            "양주시치매안심센터, 경기 양주시 화합로1426번길 90, 031-8082-7147",
            "여주시치매안심센터, 경기 여주시 여흥로160번길 12, 031-887-3685",
            "용인시기흥구치매안심센터, 경기 용인시 기흥구 신갈로58번길 11, 031-324-6961"
        };

        public ResultPage()
        {

            InitializeComponent();
            NextStepButton.Text = "다음 할일";
            ExplanationLabel1.Text = "점수 계산중입니다";

            update();
            startAni();
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
                ScoreLabel2.TextColor = Tizen.NUI.Color.Red;
                ExplanationLabel1.Text = "가까운 보건소/병원이나 치매안심센터 방문하시고";
                ExplanationLabel2.Text = "좀 더 정확한 치매검진을 받아 보시기 바랍니다";
                NextStepButton.Text = "우리동네 보건소 찾아보기";
            }
            // total score가 6을 안넘으면 치매 예방 안내
            else
            {
                ScoreLabel2.TextColor = Tizen.NUI.Color.Blue;
                ExplanationLabel1.Text = "앞으로도 운동과 외부 사회 활동을 유지하시고";
                ExplanationLabel2.Text = "치매예방수칙을 잘 실천하셔서 치매를 예방하세요";
                NextStepButton.Text = "치매예방수칙 바로가기";
            }
        }

        public void startAni()
        {
            Animation animation;
            float position = 0.0f;
            animation = new Animation(1000);
            position = 980.0f / 14.0f * QuestionPage.g_totalScore;
            animation.AnimateTo(AnimateView, "PositionX", position);

            animation.ProgressNotification = 1.0f;
       
            if (6 <= QuestionPage.g_totalScore) // 치매 가능성이 있으면 RED로 진행바 색깔 변경
            {
                AnimateView.BackgroundColor = Tizen.NUI.Color.Red;
            }
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

        private void NextStepButton_Clicked(object sender, ClickedEventArgs e)
        {
       

            if (6 <= QuestionPage.g_totalScore) // 치매가능성
            {
                Scrollable_Popup();
            }
            else
            {
                Window.Instance.GetDefaultLayer().Add(new VideoPopup()); // 치매예방수칙 동영상 출력
            }
        }

        private void Scrollable_Popup()
        {
            m_scrollableBase = new ScrollableBase();
            m_scrollableBase.Size = new Size(900, 600);
            m_scrollableBase.ScrollingDirection = ScrollableBase.Direction.Vertical;
            m_scrollableBase.ParentOrigin = new Position(0.5f, 0.5f, 0.5f);
            m_scrollableBase.PivotPoint = new Position(0.5f, 0.5f, 0.5f);
            m_scrollableBase.PositionUsesPivotPoint = true;
            Window.Instance.GetDefaultLayer().Add(m_scrollableBase);

            m_scrollableBase.ScrollDragStarted += ScrollDragStarted;
            m_scrollableBase.ScrollDragEnded += ScrollDragEnded;


            m_items = new View[20];
            int i = 0;
            for (i = 0; i < m_items.Length; i++)
            {
                m_items[i] = new TextLabel(m_dementiaInstituteList[i]);
                m_items[i].Position2D = new Position2D(0, i * 50);
                m_items[i].Size = new Size(900, 50);
                m_items[i].BackgroundColor = Color.Yellow;
                m_scrollableBase.Add(m_items[i]);
            }
            m_closeBtn = new Button();
            m_closeBtn.Size2D = new Size2D(300, 80);
            m_closeBtn.Position2D = new Position2D(300, i * 50);
            m_closeBtn.PointSize = 60;
            m_closeBtn.Text = "눌러서 종료";
            m_closeBtn.Clicked += onCloseBtnClicked;
            m_scrollableBase.Add(m_closeBtn);
        }

        private void ScrollDragStarted(object sender, ScrollEventArgs e)
        {
            // Do something in response to scroll drag started
        }

        private void ScrollDragEnded(object sender, ScrollEventArgs e)
        {
            // Do something in response to scroll drag ended
        }
        private void onCloseBtnClicked(object sender, ClickedEventArgs e)
        {
            if (m_closeBtn == null)
            {
                return;
            }
            m_closeBtn.Unparent();
            m_closeBtn.Dispose();
            m_closeBtn = null;

            for (int i = 0; i < m_items.Length; i++)
            {
                m_items[i].Unparent();
                m_items[i].Dispose();
                m_items[i] = null;
            }
            m_items = null;
            m_scrollableBase.Unparent();
            m_scrollableBase.Dispose();
            m_scrollableBase = null;

           
        }

    }
}
