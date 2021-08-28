using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BrainHealthChecker
{
    public partial class Scene1Page : View
    {
        public Scene1Page()
        {
            InitializeComponent();
        }
        private void Button_Start(object sender, ClickedEventArgs e)
        {
           
            Window window;
            window = NUIApplication.GetDefaultWindow();
            window.Add(new Scene2Page());

          //  myView.Unparent(); // remove from the tree
          //  myView.TouchEvent -= MyView_TouchEvent; // unscribe event handler
          //  myView.Dispose(); // call Dispose()
          //  myView = null; // make be unreachable for GC

        }
    }
}
