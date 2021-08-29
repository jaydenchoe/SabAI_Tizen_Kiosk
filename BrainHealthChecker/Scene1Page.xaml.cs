using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.Peripheral.Gpio;

namespace BrainHealthChecker
{
    public partial class Scene1Page : View
    {
        private const int SENSOR_MOTION_GPIO_NUMBER = 18;
        private GpioPin motionGpio;
        public Scene1Page()
        {
            InitializeComponent();

            motionGpio = new GpioPin(SENSOR_MOTION_GPIO_NUMBER, GpioPinDriveMode.Input);
            motionGpio.ValueChanged += ChangeMotion;
        }
        private void Button_Start(object sender, ClickedEventArgs e)
        {

            changeScreenTo2nd();

        }

        private void changeScreenTo2nd()
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
        private void ChangeMotion(object sender, PinUpdatedEventArgs e)
        {
            
            if (motionGpio.Read() == GpioPinValue.High)
            {
                changeScreenTo2nd();
            }
            else if (motionGpio.Read() == GpioPinValue.Low)
            {
                
            }
        }
    }
}
