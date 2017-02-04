using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using System.Threading.Tasks;

namespace HelloBlinkyRedGreen
{
    public sealed class StartupTask : IBackgroundTask
    {
        int LED_PIN_GEEN = 47;
        int LED_PIN_RED = 35;
        GpioPin pinGreen;
        GpioPin pinRed;

        private void init()
        {
            var gpio = GpioController.GetDefault();

            pinGreen = gpio.OpenPin(LED_PIN_GEEN);
            pinRed = gpio.OpenPin(LED_PIN_RED);
            pinRed.SetDriveMode(GpioPinDriveMode.Output);
            pinGreen.SetDriveMode(GpioPinDriveMode.Output);
        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            init();
            while (true)
            {
                GpioPinValue pinValue = (pinGreen.Read() == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                GpioPinValue pinValueRev = (pinValue == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                pinGreen.Write(pinValue);
                pinRed.Write(pinValueRev);
                Task.Delay(1000).Wait();
            }
        }
    }
}
