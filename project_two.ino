#include <Adafruit_CircuitPlayground.h>
#include <Adafruit_Circuit_Playground.h>

#define CAP_THRESHOLD   900
#define DEBOUNCE        150


//problems to fix/stuff to add




//sets up the varaibles the code will need
int onOff = 0; //sets onOff to off, 0, because the product will start off
int lightValue; // lightValue is the value that is recieved from the light sensor
int lightValue2; //lightValue2 is the mapped data from lightValue to be used for brightness
int brightnessValue; // brightness value is how bright the LED's are
int soundValue; // soundValue gets a value from the sound sensor to be used for reactive lights
int timer = 0; // the timer value starts at zero because no time has occured yet
int lightLoop = 1; // the lightLoop starts at 1 to go through the red to green phase of the pixels
int lightMode = 1; //controls what light variations are being shown
int lightLoop2 = 1; //controls the lightLoop for lightMode = 2
int brightMode = 100; //controls how bright the lights are
int lightLoop3 = 1; //controls the light variations for lightMode = 3
int musicMode = 0; // controls the brightness level based on sound if musicMode = 1, otherwise brightness is based on


//capButton reads the pads and determines if it's being touched with cap threshold and returns true or false
boolean capButton(uint8_t pad) {
  if (CircuitPlayground.readCap(pad) > CAP_THRESHOLD) {
    return true;  
  } else {
    return false;
  }
}


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  CircuitPlayground.begin();
  CircuitPlayground.clearPixels();

}

void loop() {
  //if sensor 6 is touched, it turns the pixels on or off depending if it's on or off
  //also when turning the pixels on the CPE will play a single note
  //and when the pixels get turned off the CPE will play two notes
  //this is to signify when it's being turned on or off to help the user 
if(capButton(6)){ //A7, controls the on/off
      if(onOff == 0){
        onOff = 1;
        CircuitPlayground.playTone(440, 250);
      }else{
        onOff = 0;
        CircuitPlayground.playTone(440, 250);
        CircuitPlayground.playTone(300, 250);
        for(int i = 0; i <=9; i++){
          CircuitPlayground.setPixelColor(i, 0, 0, 0);
        }
      }
    }

//sensor 3 controls the light mode varaible for the LED's
//if lightMode is one, then the LED's will display all the colors that it can over a loop
//if lightMode is two, then the LED's will display all blue and purple colors
//if lightMode is three, then the LED's will display all red, orange, and yellow colors
//the lightMode changes by touching the sensor
if(capButton(3)){ //scl A4, controls the light mode
  Serial.println("Touch Sensor 3 was touched");
  if(lightMode == 1){
    lightMode = 2;
    Serial.println("The lightMode is 2");
  }else if(lightMode == 2){
    lightMode = 3;
    Serial.println("The lightMode is 3");
  }else if(lightMode == 3){
    lightMode = 1;
    Serial.println("The lightMode is 1");
  }
}

//sensor one controls the brightness level when not in musicMode, by changing the value of brightMode
//if brightMode is 100, them the brightness is 100
//if brightMode is 150, then the brightness is 150
//if brightMode is 200, then the brightness is 200
//the value changes by touching the sensor
if(capButton(9)){ // TX A7, controls the brightness level
   if(brightMode == 100){
      brightMode = 150;
    }else if(brightMode == 150){
      brightMode = 200;
    }else if(brightMode == 200){
      brightMode = 100;
    }
}

//sensor 10 controls weather or not the LED's are reacting to sound or not
//by default, they don't. The musicMode variable controls this
//if musicMode is 0, then the LED'S don't react to sound
//if musicMode is 1, then the LED's react to sound
//musicMode changes by touching the sensor
if(capButton(10)){ // A3, makes the lights react to sound
  if(musicMode == 0){
    musicMode = 1;
    Serial.println("Music Mode is 1");
  }else if(musicMode == 1){
    musicMode = 0;
    Serial.println("Music Mode is 0");
  }
}

  //while the pixels are on, the CPE will read the light and sound sensor for values
  //that will change the brightness of the pixels
  if(onOff == 1){
    //if musicMode is 0, the LED's don't react to sound, and brightness is based on brightMode
    if(musicMode == 0){
      lightValue = CircuitPlayground.lightSensor();
      brightnessValue = brightMode;
      Serial.print("The brightness value is:");
      Serial.println(brightnessValue);
      //if musicMode is 1, then the LED's react to sound
    }else if(musicMode == 1){
      lightValue = CircuitPlayground.lightSensor();
      lightValue2 = map(lightValue, 0, 1023, 0, 100);
      Serial.print("The light Value is: ");
      Serial.println(lightValue2);
      soundValue = CircuitPlayground.mic.soundPressureLevel(2);
      Serial.print("The sound value is:");
      Serial.println(soundValue);
      brightnessValue = map(soundValue, 50, 80, 0, 255) + lightValue2;
      //brightnessValue = brightMode;
      Serial.print("The brightness value is:");
      Serial.println(brightnessValue);
    }

     
   if(lightMode == 1){ //lightMode = 1 will display all the colors that the CPE can display
      //while the loop is in its first iteration, the pixels will turn from red to green
      if(lightLoop == 1 && timer >=0 && timer <255){
        for(int i = 0; i <=9; i++){
          CircuitPlayground.setPixelColor(i, 255 - timer, timer, 0);
        }
        //while the loop is in its second iteration, the pixels will turn from green to blue
      }else if (lightLoop == 2 && timer >=0 && timer < 255){
        for(int i = 0; i <=9; i++){
          CircuitPlayground.setPixelColor(i, 0, 255 - timer, timer);
        }
        //while the loop is in its final iteration, the pixels will turn from blue to red
        }else if(lightLoop == 3 && timer >= 0 && timer < 255){
          for(int i = 0; i <=9; i++){
            CircuitPlayground.setPixelColor(i, timer, 0, 255 - timer);
        }
      }

      //sets the brightness of the pixels
      CircuitPlayground.setBrightness(brightnessValue);

      //the timer value gets incremented by one and when it reached 255, it goes back to zero
      //and the lightLoop value gets increased by one so the pixels can change color
      timer++;
      if(timer >= 255){
        timer = 0;
        lightLoop ++;
      }
      //if the lightLoop gets bigger than three, than the pixels go back to red and the pixel color if/else
      //statements start over again
      if(lightLoop >= 4){
        lightLoop = 1;
      }
      //prints what the timer and lightLoop values are to make sure everything is running correctly
      Serial.print("Timer value is:");
      Serial.println(timer);
      Serial.print("The lightLoop is: ");
      Serial.println(lightLoop);
    }

//end lightMode = 1

    if(lightMode == 2){ // lightMode = 2 will display all the variations of blue/purple


        if(lightLoop2 == 1){
          for(int i = 0; i <= 9; i++){ // displays colors from blue to purple
            CircuitPlayground.setPixelColor(i, timer, 0, 255-timer);
            }
        }else if(lightLoop2 == 2){
          for(int i = 0; i <= 9; i++){ // displays colors from purple to blue
            CircuitPlayground.setPixelColor(i, 140-timer, 0, 115+timer);
          }
        }
         

     
      timer++;
     
     
       if(lightLoop2 == 1 && timer >= 140){
        lightLoop2 = 2;
        timer = 0;
      }else if(lightLoop2 == 2 && timer >= 140){
        lightLoop2 = 1;
        timer = 0;
      }
      Serial.print("The timer value is: ");
      Serial.println(timer);
    }

//end lightMode = 2

    if(lightMode == 3){ // lightMode = 3 will display all the color varaitions of red/orange/yellow


    if(lightLoop3 == 1){
      for(int i = 0; i <= 9; i++){ // displays colors from red to yellow
        CircuitPlayground.setPixelColor(i, 255 - timer, timer, 0);
      }
    }else if(lightLoop3 == 2){
      for(int i = 0; i <= 9; i++){ // displays colors from yellow to red
        CircuitPlayground.setPixelColor(i, 155 + timer, 100 - timer, 0);
      }
    }



     
      timer++;
     
       if(lightLoop3 == 1 && timer >= 100){
        lightLoop3 = 2;
        timer = 0;
      }else if(lightLoop3 == 2 && timer >= 100){
        lightLoop3 = 1;
        timer = 0;
      }

      Serial.print("The timer value is: ");
      Serial.println(timer);
    }
  }

//end lightMode 3
    delay(DEBOUNCE);
}
