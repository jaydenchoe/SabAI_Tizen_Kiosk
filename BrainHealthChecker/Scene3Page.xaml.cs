using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BrainHealthChecker
{
    public partial class Scene3Page : View
    {
        public Scene3Page()
        {
            InitializeComponent();
        }

        private void demantiaButton_Clicked(object sender, ClickedEventArgs e)
        {
            Window window;
            window = NUIApplication.GetDefaultWindow();
            window.Add(new QuestionPage());
        }
    }
}
