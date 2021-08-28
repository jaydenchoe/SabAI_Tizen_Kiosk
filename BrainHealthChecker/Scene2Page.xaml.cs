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

            SetButtonStyle(button);
        }
        private void SetButtonStyle(Button button)
        {
            button.TextLabel.PixelSize = 25.0f;
        }
    }
}
