# Lesson2 Hello Blinky Red and Green
This project is using Raspberry PI, Windows 10 IoT Core and onboard red-green LEDs which are going to blink alternately.

Lesson #1 in this series are:https://github.com/LeivoSepp/Lesson1-HelloBlinky

Lesson #3 in this series: https://github.com/LeivoSepp/Lesson3-HelloButton

## Why is it worth to try this program?

1. You will learn, how to use method or we can say also "code block"
2. You will learn, how to put your LEDs blinking with different style of coding
	1. Using IF-ELSE statement
	2. Using ternary condition (?:)
	3. using plain coding

## Lets start from the beginning with the code explanation
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
### What is inside of this init code-block?

First we will create a gpio controller to let our code know all about the pins.
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
The first row is init(); that is our previously created code-block for setting up pins.
```c#
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            init();
```

# Three different methods to blink LEDs
Now we are ready to start alternatevly blink red and green LEDs
while(true) tells to code, that "run forewer everything which inside of me".

# #1 Method to blink LEDs, using IF-ELSE statement

1. check green LED status, is it on or off?
2. if green LED is ON (GpioPinValue.High)
	1. turn green LED OFF
	2. turn red LED ON
3. jump over else and wait 1 second (1000 ms)
4. start again checking green LED statuses
5. now green LED is OFF, so code will jump to ELSE
	1. turn green LED ON
	2. turn red LED OFF
6. The code will wait again 1 second and then jumps to start.

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

1. creating variable to hold pin statuses (on or off) GpioPinValue pinValue
	1. check green LED statuses (pinGreen.Read() == GpioPinValue.High)
	2. if green LED is ON, then our variable pinValue will get a value GpioPinValue.Low 
2. creating another variable to hold pin statuses (on or off) GpioPinValue pinValueRev
	1. check pinValue statuses (pinValue == GpioPinValue.High)
	2. if pinValue is LOW, then pinValueRev get a value GpioPinValue.High
3. turn green LED on or off, based pinValue pinGreen.Write(pinValue);
4. turn red LED on or off, based on pinValueRev pinRed.Write(pinValueRev);
5. wait 1 second and start again

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

1. set green LED OFF
2. set red LED ON
3. wait 1 second
4. set green LED ON
5. set red LED OFF
6. wait 1 second

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

# Which is the best method to use?
It is always tricky question :)

Which method to use, is depending on you and what is your coding level. If you are beginner, then most probably you will use method 3, if you have already some knowledge, you probably will use method 1. 
Many skilled programmers would prefer method 2.

I can say that there are other techniques exists as well, for example use methods, but we will keep it plain and simple at the moment.
