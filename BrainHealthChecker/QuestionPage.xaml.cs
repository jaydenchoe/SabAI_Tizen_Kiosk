using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BrainHealthChecker
{
    public partial class QuestionPage : View
    {
        // 치매 질문 리스트
        private string[] m_dementiaQuestions = new string[] {
            "자신의 기억력에 문제가 있다고 생각하십니까?", // #1
            "자신의 기억력이 10년 전보다 나빠졌다고 생각하십니까?", // #2
            "자신의 기억력이 같은 또래의 다른 사람들에 비해 나쁘다고 생각하십니까?", // #3
            "기억력 저하로 인해 일상생활에 불편을 느끼십니까?", // #4
            "최근에 일어난 일을 기억하는 것이 어렵습니까?", // #5
            "며칠 전에 나눈 대화 내용을 기억하기 어렵습니까?", // #6
            "며칠 전에 한 약속을 기억하기 어렵습니까?", // #7
            "친한 사람의 이름을 기억하기 어렵습니까?", // #8
            "물건 둔 곳을 기억하기 어렵습니까?", // #9
            "이전에 비해 물건을 자주 잃어버립니까?", // #10
            "집 근처에서 길을 잃은 적이 있습니까?", // #11
            "가게에서 2-3가지 물건을 사려고 할 때 물건 이름을 기억하기 어렵습니까?", // #12
            "가스불이나 전기불 끄는 것을 기억하기 어렵습니까?", // #13
            "자주 사용하는 전화번호(자신 혹은 자녀의 집)을 기억하기 어렵습니까?" // #14
        };
        // 치매 질문에 대한 답 배열과 합산값
        private int[] m_answerList = new int[14];
        public static int g_totalScore = 0;
        // 현재 질문 인덱스 (0~13)
        private int m_questionIndex = 0;
        // 전화번호, 성별, 나이를 저장하는 전역 변수들
        public static int g_phoneNumber = 0;
        public static int g_gender = 0; // 0은 남성, 1은 여성, 2는 기타
        public static int g_age = 0;


        public QuestionPage()
        {
            InitializeComponent();
            m_questionIndex = 0; // 최초 질문 인덱스로 바꾸고
            g_totalScore = 0;
            questionLabel.Text = m_dementiaQuestions[m_questionIndex]; // 질문을 Text Label에 입력
        }

        private void NextButton_Clicked(object sender, ClickedEventArgs e)
        {
            if (13 <= m_questionIndex)
            { // 끝까지 갔으면 결과 페이지로 이동
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

                view = new ResultPage();
                Scene1.g_pre_view = view;
                window.Add(view);
            }
            else
            { // 그렇지 않으면 현재 질문 답을 저장하고 다음 질문 업데이트
                if (RadioYes.IsSelected)
                {
                    m_answerList[m_questionIndex] = 1; // yes
                    QuestionPage.g_totalScore += 1;
                }
                else
                {
                    m_answerList[m_questionIndex] = 0; // no
                }
                m_questionIndex++; // 다음 질문 인덱스로 이동
                questionLabel.Text = m_dementiaQuestions[m_questionIndex]; // 질문을 Text Label에 입력
                RadioYes.IsSelected = false;
                RadioNo.IsSelected = true;
                if (13 <= m_questionIndex)
                { // 마지막이면 버튼 캡션을 변경
                    NextButton.Text = "눌러서 결과 화면으로";
                }
            }
        }
        private void StoreScore()
        {
            // 클라우드 저장용

            // m_answerList의 값 저장
            // public static int g_totalScore의 값을 저장
            // public static int g_phoneNumber (전화번호) 값 저장
            // public static int g_gender (성별) 값 저장 // 0은 남성, 1은 여성, 2는 기타
            // public static int g_age (나이) 값

        }
    }
}
