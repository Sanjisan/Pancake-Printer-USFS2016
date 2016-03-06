#include <Servo.h>
#include <math.h>

struct ServoDef {
  //current frequency
  int cfreq;
  //desired frequency
  int dfreq;
  
  //current angle
  double ctheta;
  //desired angle
  double dtheta;
  
  //current voltage (pot reading)
  int cvolt;
  //desired voltage
  int dvolt;
  
  //center (90 degree) freq
  int centerf;
  //center voltage
  int centerv;

  //min freq
  int minf;
  //max freq
  int maxf;
  
  //min voltage
  int minv;
  //max voltage
  int maxv;
  
  //freqency step
  double stepf;
  //voltage step
  double stepv;
  
  // Servo
  Servo servo;

  //feedback pin
  int fpin;
};

struct Extruder {
  int on;
  int off;
  Servo servo;
};

//


#define PivotPin 9
#define ShoulderPin 7
#define ElbowPin 8
#define WristPin 11
#define GripperPin 10

#define PivotVinPin 16 //14
#define ShoulderVinPin 14
#define ElbowVinPin 15

ServoDef pivot;
ServoDef shoulder;
ServoDef elbow;
Servo wrist;
Extruder gripper;

void setup() {
  //attach all servos
  pivot.servo.attach(PivotPin);
  shoulder.servo.attach(ShoulderPin);
  elbow.servo.attach(ElbowPin);
  gripper.servo.attach(GripperPin);
  wrist.attach(WristPin);

  //attach feedback pins
  pivot.fpin = PivotVinPin;
  shoulder.fpin = ShoulderVinPin;
  elbow.fpin = ElbowVinPin;


  shoulder.servo.writeMicroseconds(1424);
  elbow.servo.writeMicroseconds(1132);
  pivot.servo.writeMicroseconds(1439);
  gripper.servo.writeMicroseconds(1000);
  wrist.writeMicroseconds(1540);
  
  //start the serial monitor
  Serial.begin(9600);
  //set the ADC to 16 bit
  analogReadRes(16);
  analogReadAveraging(32);

  pivot.cfreq = 1500;
  shoulder.cfreq = 1500;
  elbow.cfreq = 1500;
  //150
  //shoulder.dvolt = 11244;
  //elbow.dvolt = 21380;
  
  
}

  int x = 300;
  int y = 200;
  int z = 0;

  //adjust for r direction on small moves
  int rdir = 0;
  int rammt = 8;
  
void loop() {
  
  
  char axis;
  int value;
  if(Serial.available() > 0)
  {
    bool changed = false;
    byte count = 0;
    while (Serial.available() && count < 3)
    {
      axis = Serial.read();
      value = Serial.parseInt();
      if (axis == 'x')
      {
        x = value;
        changed = true;
      }
      else if (axis == 'y')
      {
        y = value;
        changed = true;
      }
      else if (axis == 'z')
      {
        z = value;
        changed = true;
      }
      count++;
    }
    if (changed)
    {
      moveArm(x,y,z);
      pivot.cvolt = analogRead(pivot.fpin);
      shoulder.cvolt = analogRead(shoulder.fpin);
      elbow.cvolt = analogRead(elbow.fpin);
      //Print values to serial
      //Serial.print("x = ");
      Serial.print(x);
      //Serial.print(" | y = ");
      Serial.print("\t");
      Serial.print(y);
      //Serial.print(" | P = ");
      Serial.print("\t");
      //Serial.print(pivot.cvolt);
      //Serial.print(" | ");
      Serial.print(z);
      Serial.print("\t");
      Serial.print(pivot.cfreq);
      Serial.print("\t");
      //Serial.print(" | S = ");
      //Serial.print(" | y = ");
      //Serial.print(shoulder.cvolt);
      //Serial.print(" | ");
      //Serial.print(" | y = ");
      Serial.print(shoulder.cfreq);
      //Serial.print(" | E = ");
      Serial.print("\t");
      //Serial.print(elbow.cvolt);
      //Serial.print(" |  ");
      //Serial.print(" | y = ");
      Serial.println(elbow.cfreq);
    }
  }
}

void moveArm(double x, double y, double z)
{
  int xmin = 0;
  int ymin = 0;
  int zmin = -87;
  
  int xmax = 600;
  int ymax = 300;
  int zmax = 100;

  if (z > zmax)
    z = zmax;
  if (z < zmin)
    z = zmin;
  
  int xcenter = 400;
  int ycenter = 0;

  int rmin = 90;
  int rmax = 410;

  double r = sqrt(pow(x-xcenter,2) + pow(y-ycenter,2));

  if (r > rmax)
    r = rmax;
  if (r < rmin)
    r = rmin;
  
  double ThetaR = atan2((y-ycenter),(x-xcenter));
  
  double d1 = 21;
  double d2 = 148;
  double d3 = 160;
  double d4r = 94;
  double d4z = 40;

  double Ar = d1;
  double Az = 0;

  double Cr = r - d4r;
  double Cz = z + d4z;

  double d5 = sqrt(pow((Cr - Ar),2) + pow(Cz,2));
  double Theta1 = atan2( Cz ,(Cr - Ar));
  double Theta2 = acos((pow(d5,2)+pow(d2,2)-pow(d3,2))/(2*d5*d2));

  double ThetaA = Theta1 + Theta2;

  double Br = d2*(cos(ThetaA)) + Ar;
  double Bz = d2*(sin(ThetaA)) + Az;

  double ThetaB = atan2((Cr-Br),(Bz-Cz));
  
  //Translational Formulas
  shoulder.cfreq = 672.78 * ThetaA + 544.53;
  elbow.cfreq = 627.82 * ThetaB + 1031.2;
  pivot.cfreq = 558.65 * ThetaR + 561.8;

  shoulder.servo.write(shoulder.cfreq);
  elbow.servo.write(elbow.cfreq);
  pivot.servo.write(pivot.cfreq);

  
}


