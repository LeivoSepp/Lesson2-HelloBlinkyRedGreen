# Lesson2-Hello Blinky Red and Green
This project is using Raspberry PI, Windows 10 IoT Core and putting onboard red-green LEDs blinking.

<pre style="font-family:Consolas;font-size:13;color:black;background:white;"><span style="color:blue;">namespace</span>&nbsp;HelloBlinkyRedGreen
{
&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:blue;">public</span>&nbsp;<span style="color:blue;">sealed</span>&nbsp;<span style="color:blue;">class</span>&nbsp;<span style="color:#2b91af;">StartupTask</span>&nbsp;:&nbsp;<span style="color:#2b91af;">IBackgroundTask</span>
&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:green;">//First,&nbsp;we&nbsp;need&nbsp;to&nbsp;create&nbsp;variables&nbsp;to&nbsp;hold&nbsp;Red&nbsp;and&nbsp;Green&nbsp;LEDs&nbsp;pin&nbsp;numbers</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:blue;">int</span>&nbsp;LED_PIN_GEEN&nbsp;=&nbsp;47;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:blue;">int</span>&nbsp;LED_PIN_RED&nbsp;=&nbsp;35;
 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:green;">//here&nbsp;we&nbsp;are&nbsp;creating&nbsp;pin-objects,&nbsp;which&nbsp;represent&nbsp;actual&nbsp;pins</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:green;">//we&nbsp;need&nbsp;them,&nbsp;because&nbsp;we&nbsp;need&nbsp;to&nbsp;turn&nbsp;LEDs&nbsp;on&nbsp;and&nbsp;off&nbsp;</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:#2b91af;">GpioPin</span>&nbsp;pinGreen;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:#2b91af;">GpioPin</span>&nbsp;pinRed;</pre>