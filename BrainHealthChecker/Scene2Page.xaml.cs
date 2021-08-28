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
            window = NUIApplication.GetDefaultWindow();
            window.Add(new Scene3Page());
        }
    }
}
