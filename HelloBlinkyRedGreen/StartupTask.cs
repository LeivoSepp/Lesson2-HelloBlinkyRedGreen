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
            if (gpio == null)
            {
                return;
            }
            pinGreen = gpio.OpenPin(LED_PIN_GEEN);
            pinRed = gpio.OpenPin(LED_PIN_RED);
            pinRed.Write(GpioPinValue.High);
            pinRed.SetDriveMode(GpioPinDriveMode.Output);
            pinGreen.Write(GpioPinValue.High);
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

                //GpioPinValue pinValue = pinGreen.Read();
                //if (pinValue == GpioPinValue.High)
                //{
                //    pinGreen.Write(GpioPinValue.Low);
                //    pinRed.Write(GpioPinValue.High);
                //}
                //else
                //{
                //    pinGreen.Write(GpioPinValue.High);
                //    pinRed.Write(GpioPinValue.Low);
                //}
                Task.Delay(1000).Wait();
            }
        }
    }
}
