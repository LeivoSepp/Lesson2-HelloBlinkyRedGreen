# Lesson2 Hello Blinky Red and Green
This project is using Raspberry PI, Windows 10 IoT Core and onboard red-green LEDs which are going to blink alternately.

# Why is it worth to try this program?
1. You will learn, how to use method or we can say also "code block"
2. You will learn, how to put your LEDs blinking with different style of coding
	a) Using IF-ELSE statement
	b) Using ternary condition (?:)
	c) using plain coding

# Lets start from the beginning with the code explanation
First, we will create variables to hold Red and Green LEDs pin numbers
```c#
        int LED_PIN_GEEN = 47;
        int LED_PIN_RED = 35;
```

Our program needs to know about pins to turn them on and off, so we will create variables for pin-objects which represent actual pins. 
We are setting later some parameters for them as well.
```c#
        GpioPin pinGreen;
        GpioPin pinRed;
```

Here we are creating a method or let say small code block and we will name it "init".
This code block will executed later, only one time in the beginning of the program.
```c#
        private void init()
        {
            var gpio = GpioController.GetDefault();
            pinGreen = gpio.OpenPin(LED_PIN_GEEN);
            pinRed = gpio.OpenPin(LED_PIN_RED);
            pinRed.SetDriveMode(GpioPinDriveMode.Output);
            pinGreen.SetDriveMode(GpioPinDriveMode.Output);
        }
```
What is inside of this init code-block?

First we will create a gpio-object and checking is it successful or not.
```c#
            var gpio = GpioController.GetDefault();
```

Here we actually set the parameters for our previously created pins.
Our program need to know two things:
1. what is the pin number? "your pin number is 35"
2. is that pin input or output? "this pin is output"

```c#
            pinGreen = gpio.OpenPin(LED_PIN_GEEN);
            pinRed = gpio.OpenPin(LED_PIN_RED);
            pinRed.SetDriveMode(GpioPinDriveMode.Output);
            pinGreen.SetDriveMode(GpioPinDriveMode.Output);
```

Actual execute of the code will start here, with the method "Run"
The first row is init(); that is our previously created code-block for setting up pins
```c#
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            init();
```

# Three different methods to blink LEDs
Now we are ready to start alternatevly blink red and green LEDs
while(true) tells to code, that "run forewer everything which inside of me".

# #1 Method to blink LEDs, using IF-ELSE statement
a) check green LED status, is it on or off?
b) if green LED is ON (GpioPinValue.High)
	b1) turn green LED OFF
	b2) turn red LED ON
c) jump over else and wait 1 second (1000 ms)
d) start again checking green LED statuses
e) now green LED is OFF, so code will jump to ELSE
	e1) turn green LED ON
	e2) turn red LED OFF

Code wait again 1 second and jumps to start.
```c#
            while (true)
            {
                if (pinGreen.Read() == GpioPinValue.High)
                {
                    pinGreen.Write(GpioPinValue.Low);
                    pinRed.Write(GpioPinValue.High);
                }
                else
                {
                    pinGreen.Write(GpioPinValue.High);
                    pinRed.Write(GpioPinValue.Low);
                }
                Task.Delay(1000).Wait();
            }
```

# #2 Method to blink LEDs, using ternary condition

First, we need to understand how ternary condition is working. Actually it is like IF-ELSE statement, but all in one line and using ? for IF and : for ELSE
Lets go step-by-step

a) creating variable to hold pin statuses (on or off) GpioPinValue pinValue
	a1) check green LED statuses (pinGreen.Read() == GpioPinValue.High)
	a2) if green LED is ON, then our variable pinValue will get a value GpioPinValue.Low 
b) creating another variable to hold pin statuses (on or off) GpioPinValue pinValueRev
	b1) check pinValue statuses (pinValue == GpioPinValue.High)
	b2) if pinValue is LOW, then pinValueRev get a value GpioPinValue.High
c) turn green LED on or off, based pinValue pinGreen.Write(pinValue);
d) turn red LED on or off, based on pinValueRev pinRed.Write(pinValueRev);
e) wait 1 second and start again

```c#
            while (true)
            {
                GpioPinValue pinValue = (pinGreen.Read() == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                GpioPinValue pinValueRev = (pinValue == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;
                pinGreen.Write(pinValue);
                pinRed.Write(pinValueRev);
				Task.Delay(1000).Wait();
            }
```

# #3 Method to blink LEDs, using plain code

This method could be most easy to understand, but developers like it least.
a) set green LED OFF
b) set red LED ON
c) wait 1 second
a) set green LED ON
b) set red LED OFF
c) wait 1 second

```c#
            while (true)
            {
                pinGreen.Write(GpioPinValue.Low);
                pinRed.Write(GpioPinValue.High);
                Task.Delay(1000).Wait();
                pinGreen.Write(GpioPinValue.High);
                pinRed.Write(GpioPinValue.Low);
                Task.Delay(1000).Wait();
            }
```

Which method to use, is depending on you and what is your coding level. If you are beginner, then most probably you will use method 3, if you have already some knowledge, you probably will use method 1. 
Many skilled programmers would prefer method 2.
I can say that there are other techniques exists as well, for example use methods, but we will keep it plain and simple at the moment.