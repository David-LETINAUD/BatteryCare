#include <SoftwareSerial.h>
#define RELAY_OUTPUT 4

const int rx = 3;
const int tx = 1;

SoftwareSerial mySerial(rx, tx);
int i = 0;
char buf[12];
int inByte = 0 ;

void setup()
{
  pinMode(rx, INPUT);
  pinMode(tx, OUTPUT);
  pinMode(RELAY_OUTPUT, OUTPUT);
  digitalWrite(RELAY_OUTPUT,HIGH);    // turn the RELAY off
  
  mySerial.begin(9600);
}

void loop()
{
  if (mySerial.available() > 0)
  {
    inByte = mySerial.read();
    if (inByte == 'c')
    {
      digitalWrite(RELAY_OUTPUT, LOW);   // turn the RELAY on 
    }
    else if (inByte == 'd')
    {
      digitalWrite(RELAY_OUTPUT,HIGH);    // turn the RELAY off 
    }
  }
}
