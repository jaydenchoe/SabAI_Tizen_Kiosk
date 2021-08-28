using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BrainHealthChecker
{
  
    public partial class Scene2Page : View
    {
        public Scene2Page()
        {
            InitializeComponent();

            SetButtonStyle(buttonNext);
        }
        private void SetButtonStyle(Button button)
        {
            button.TextLabel.PixelSize = 25.0f;
        }

        private void buttonNext_Clicked(object sender, ClickedEventArgs e)
        {
            Window window;

        // 전화번호를 전역변수에 저장
            QuestionPage.g_phoneNumber = int.Parse(phoneField.Text);
        // 성별을 전역변수에 저장
            if ( RadioMan.IsSelected )
            {
                QuestionPage.g_gender = 0;
            } else if ( RadioWoman.IsSelected)
            {
                QuestionPage.g_gender = 1;
            } else
            {
                QuestionPage.g_gender = 2;
            }
        // 나이를 전역변수에 저장
            QuestionPage.g_age = int.Parse( ageField.Text);

            window = NUIApplication.GetDefaultWindow();
            window.Add(new Scene3Page());
        }
    }
}
