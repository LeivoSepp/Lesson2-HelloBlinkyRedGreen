# Lesson2 Hello Blinky Red and Green
This project uses Raspberry PI, Windows 10 IoT Core and the onboard red-green LEDs which will be blinking alternatingly.

Lesson #1 in this series: https://github.com/LeivoSepp/Lesson1-HelloBlinky

Lesson #3 in this series: https://github.com/LeivoSepp/Lesson3-HelloButton

## Why use this program?

1. You will learn how to use method, also known as "code block"
2. You will learn how to make your LEDs bling using different styles of coding
	1. Using IF-ELSE statement
	2. Using ternary condition (?:)
	3. using plain coding

## Let's start by explaining the code from the start
First, we will create variables to hold the Red and Green LED pin numbers
```c#
        int LED_PIN_GEEN = 47;
        int LED_PIN_RED = 35;
```


Our program needs to know about pins to turn them off and on, so we will create variables which will be representing actual pins. 
We are setting later some parameters for them as well.
```c#
        GpioPin pinGreen;
        GpioPin pinRed;
```

Here we'll create a method, also known as a code block and we'll be naming it "init".
This code block will be executed for only once at the beginning of the program.
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
### What is in this init code-block?

First we will create a gpio controller to let our code know all about the pins.
```c#
            var gpio = GpioController.GetDefault();
```

Then we will set the parameters for our previously created pins.
Our program need to know two things:

1. what is the pin number? "your pin number is 35"
2. is the pin an input or an output? "this pin is an output"

```c#
            pinGreen = gpio.OpenPin(LED_PIN_GEEN);
            pinRed = gpio.OpenPin(LED_PIN_RED);
            pinRed.SetDriveMode(GpioPinDriveMode.Output);
            pinGreen.SetDriveMode(GpioPinDriveMode.Output);
```
Take a look at this picture, GPIO is all the pins and pin is one particular pin. 
Raspberry PI has two special pins which are to control the green and red LED integrated on the board. 
The green LED’s pin number is 35 and the red’s pin number is 47.
![image](https://cloud.githubusercontent.com/assets/13704023/22621382/13b33e60-eb2b-11e6-9776-cf6ca9691280.png)

Actual execution of the code will start here, with the method "Run"
The first row is init(); that is our previously created code-block for setting up pins.
```c#
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            init();
```

# Three different methods to make LEDs blink
Now we are ready to have the red and Green LEDs blink alternatingly
while(true) tells the code to "run everything inside of me forever".

# #1 Method to blink LEDs, using an IF-ELSE statement

1. check the status of the green LED, is it off or on?
2. if green LED is ON (GpioPinValue.High)
	1. turn green LED OFF
	2. turn red LED ON
3. jump over else and wait 1 second (1000 ms)
4. start again by checking the status of the green LED
5. this time, green LED is OFF, and thus code will jump to ELSE
	1. turn green LED ON
	2. turn red LED OFF
6. The code will wait again for 1 second and then jumps to start.

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

First, we need to understand how ternary condition works. It works like an IF-ELSE clause, but everything is in one line and uses a "?" for IF and a ":" for ELSE
Lets go step-by-step

1. create a variable to hold the status of a pin (on or off) GpioPinValue pinValue
	1. check the status of the green LED (pinGreen.Read() == GpioPinValue.High)
	2. if the green LED is ON, then our variable pinValue will get a value GpioPinValue.Low 
2. create another variable to hold the inverted status of a pin (on or off) GpioPinValue pinValueRev
	1. check the status of pinValue (pinValue == GpioPinValue.High)
	2. if pinValue is LOW, then pinValueRev will be given a value of GpioPinValue.High
3. turn the green LED off or on, based on pinValue pinGreen.Write(pinValue);
4. turn the red LED off or on, based on pinValueRev pinRed.Write(pinValueRev);
5. wait for 1 second and start again

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

This method could be the easiest to understand, but developers like it the least.

1. set the green LED OFF
2. set the red LED ON
3. wait 1 second
4. set the green LED ON
5. set the red LED OFF
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
This is always a tricky question :)

Which method to use depends on you and your coding level. If you are a beginner, then you'll most probably use the third method, if you already have some knowledge, you will probably use the first methog. 
Many skilled programmers however, prefer the second method.

There are of course many more ways to do this for example by using methods. For now however, I will keep it plain and simple.
