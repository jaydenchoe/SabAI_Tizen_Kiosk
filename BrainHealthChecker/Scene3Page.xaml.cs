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
            View view;

            window = NUIApplication.GetDefaultWindow();
            if (Scene1.g_pre_view != null)
            {
                window.Remove(Scene1.g_pre_view);
                Scene1.g_pre_view.Unparent();
                Scene1.g_pre_view.Dispose();
                Scene1.g_pre_view = null;
            }
            view = new QuestionPage();
            Scene1.g_pre_view = view;
            window.Add(view);
        }
    }
}
