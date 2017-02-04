using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using System.Threading.Tasks;

namespace HelloBlinkyRedGreen
{
    public sealed class StartupTask : IBackgroundTask
    {
        //First, we need to create variables to hold Red and Green LEDs pin numbers
        int LED_PIN_GEEN = 47;
        int LED_PIN_RED = 35;

        //here we are creating pin-objects, which represent actual pins
        //we need them, because we need to turn LEDs on and off 
        GpioPin pinGreen;
        GpioPin pinRed;

        //Now we are creating a small set of code, wich will be executed one time
        //we call this code with a name "init"
        private void init()
        {
            //first, we are creating an object for all pins and we call it gpio
            var gpio = GpioController.GetDefault();
            if (gpio == null)
            {
                return;
            }
            //here we are actually setting parameters for our previously created pins
            //we need to tell the program two things:
            // 1. "your pin number is 35"
            // 2. "this pin is output"
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

                GpioPinValue pinValue = pinGreen.Read();
                if (pinValue == GpioPinValue.High)
                {
                    pinGreen.Write(GpioPinValue.Low);
                    pinRed.Write(GpioPinValue.High);
                }
                else
                {
                    pinGreen.Write(GpioPinValue.High);
                    pinRed.Write(GpioPinValue.Low);
                }

                //GpioPinValue pinValue = (pinGreen.Read() == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                //GpioPinValue pinValueRev = (pinValue == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                //pinGreen.Write(pinValue);
                //pinRed.Write(pinValueRev);

                Task.Delay(1000).Wait();
            }
        }
    }
}
