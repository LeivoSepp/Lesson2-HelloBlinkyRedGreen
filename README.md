# Lesson2-Hello Blinky Red and Green
This project is using Raspberry PI, Windows 10 IoT Core and putting onboard red-green LEDs blinking.

```c#
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
		```