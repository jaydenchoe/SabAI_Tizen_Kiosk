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
            View view;
            window = NUIApplication.GetDefaultWindow();

            if (Scene1.g_pre_view != null)
            {
                window.Remove(Scene1.g_pre_view);
                Scene1.g_pre_view.Unparent();
                Scene1.g_pre_view.Dispose();
                Scene1.g_pre_view = null;
            }
      
            view = new Scene2Page();
            Scene1.g_pre_view = view;
            window.Add(view);

          //  myView.Unparent(); // remove from the tree
          //  myView.TouchEvent -= MyView_TouchEvent; // unscribe event handler
          //  myView.Dispose(); // call Dispose()
          //  myView = null; // make be unreachable for GC

        }
    }
}
