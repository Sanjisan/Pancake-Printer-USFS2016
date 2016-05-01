#include <Servo.h>
#include <math.h>

#define EXTRUSIONSTART 500
#define EXTRUSIONSTOP 500

#define MINMOVETIME 10
#define MAXMOVETIME 1000

#define PivotPin 9
#define ShoulderPin 7
#define ElbowPin 8
#define WristPin 11
#define GripperPin 10

#define PivotVinPin A2 //14
#define ShoulderVinPin A0
#define ElbowVinPin A1

//bitmap to be searched
#define WorkspaceX 100
#define WorkspaceY 400

byte Workspace[WorkspaceY][WorkspaceX];



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
  bool extruding;
  Servo servo;
};

ServoDef pivot;
ServoDef shoulder;
ServoDef elbow;
Servo wrist;
Extruder gripper;

long int timestamp;

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

  //extruder on/off
  gripper.on = 2000;
  gripper.off = 1000;
  gripper.extruding = false;

  shoulder.servo.writeMicroseconds(1424);
  elbow.servo.writeMicroseconds(1132);
  pivot.servo.writeMicroseconds(1463);
  gripper.servo.writeMicroseconds(gripper.off);
  wrist.writeMicroseconds(1600);
  
  //start the serial monitor
  Serial.begin(9600);
  //set the ADC to 16 bit
  analogReadRes(12);
  analogReadAveraging(32);

  pivot.cfreq = 1500;
  shoulder.cfreq = 1500;
  elbow.cfreq = 1500;
  //150
  //shoulder.dvolt = 11244;
  //elbow.dvolt = 21380;
  
  
}

  int x = 400;
  int y = 200;
  int z = 0;

  //adjust for r direction on small moves
  int rdir = 0;
  int rammt = 8;

  bool randomMoves = false;
  bool manualMoves = false;
  bool paintLayer = true;

  bool firstMove = true;
  
void loop() {
  if (randomMoves)
  {
    doRandomMoves();
  }

  if (manualMoves)
  {
    doRandomMoves();
  }

  if (paintLayer)
  {
    gripper.extruding = false;
    gripper.servo.writeMicroseconds(gripper.off);
    firstMove = true;
    doPaintLayer();
  }
}

void initilizeWorkspace()
{
  for (int i = 0; i < WorkspaceY; i++){
    for (int j = 0; j < WorkspaceX; j++){
      Workspace[i][j] = 0;
    }
  }
}

void doPaintLayer()
{
  //init workspace
  initilizeWorkspace();
  
  //move to waiting position
  x = 400;
  y = 250;
  z = 50;
  moveArm(x,y,z);
  
  char option;
  int value;
  int imageX = 0;
  int imageY = 0;
  int imageZ = 0;
  int imageWidth = 0;
  int imageHeight = 0;
  
  int count = 0;
  //read the image dimentions from serial
  while (count < 5)
  {
    
    if (Serial.available())
    {
      option = Serial.read();
      value = Serial.parseInt();
      if (option == 'x')
      {
        imageX = value;
      }
      else if (option == 'y')
      {
        imageY = value;
      }
      else if (option == 'z')
      {
        imageZ = value;
      }
      else if (option == 'w')
      {
        imageWidth = value;
      }
      else if (option == 'h')
      {
        imageHeight = value;
      }
      count++;
      Serial.print(option);
      Serial.print(" - ");
      Serial.println(value);
    }
    /**
    else
    {
      delay(1000);
      Serial.println("Waiting");
    }
    **/
  }
  count = 0;
  int wsX = imageX;
  int wsY = imageY;
  //read from serial and store the picture
  while ( count < ((imageWidth * imageHeight - 1) / 8 + 1))
  {
    if ( Serial.available())
    {
      //get a byte
      byte eightPixels = Serial.read();
      /**
      Serial.print("I got :");
      Serial.println(eightPixels);
      **/
      //step through each bit in the byte
      for (byte i = 0; i < 8; i++)
      {
        if (bitRead(eightPixels, i))
        {
          bitSet(Workspace[wsY][wsX / 8], (wsX % 8));
        }
        //update the x and y positions;
        wsX++;
        if (wsX >= (imageX + imageWidth))
        {
          wsX = imageX;
          wsY++;
        }
      }
      count++;
    }
    /**
    else
    {
      delay(1000);
      Serial.print("waiting for ");
      Serial.print(((imageWidth * imageHeight - 1) / 8 + 1) - count);
      Serial.println("bytes");
    }
    **/
  }
  /**
  if (count)
  {
    Serial.println("All bytes recieved! Here is the image:");
    for (int i = imageY; i < (imageY + imageHeight); i++)
    {
      Serial.println();
      for (int j = (imageX / 8); j < ((imageX + imageWidth -1)/8 +1); j++)
      {
        Serial.print(Workspace[i][j]);
        Serial.print(" ");
      }
    }
  }
  **/

  //start searching image from the home position x400y200
  x = imageX;
  y = imageY;
  bool pointsExist = false;
  bool pointFound = false;
  bool finishedLayer = false;
  while (1)
  {
    pointsExist = false;
    //check if any points still exist
    for (int i = imageY; i < (imageY + imageHeight); i++)
    {
      for (int j = (imageX / 8); j < ((imageX + imageWidth - 1) / 8 + 1 ); j++)
      {
        if (Workspace[i][j])
        {
          //Serial.println("The Workspace still has values");
          pointsExist = true;
          finishedLayer = false;
          break;
        }
      }
      if (pointsExist)
        break;
    }
    if (!pointsExist)
    {
      //Serial.println("No more points!");
      break;
    }
    //find the nearest point and go to it
    pointFound = false;
    if (pointsExist)
    {
      //Serial.println("Searching For a point");
      for (int i = 1; i < imageWidth; i++)
      {
        //search Top and bottom (variable x constant y
        for (int j = (x - i); j <= (x + i); j++)
        {
          if ( j >= imageX && j < imageX + imageWidth)
          {
            //top border
            if ( (y - i) >= imageY )
            {
              if (bitRead(Workspace[y-i][j / 8], (j % 8)))
              {
                wsX = j;
                wsY = y-1;
                pointFound = true;
                /*
                Serial.print("I found:");
                Serial.print(wsX);
                Serial.print(",");
                Serial.println(wsY);
                */
                break;
              }
            }
            //bottom border
            if ( (y + i) < (imageY + imageHeight) )
            {
              if (bitRead(Workspace[y+i][j / 8], (j % 8)))
              {
                wsX = j;
                wsY = y+1;
                pointFound = true;
                /*
                Serial.print("I found:");
                Serial.print(wsX);
                Serial.print(",");
                Serial.println(wsY);
                */
                break;
              }
            }
          }
        }
        if (pointFound)
          break;
        //search Left and Right (variable y constant x
        for (int j = (y - i); j <= (y + i); j++)
        {
          if ( j >= imageY && j < (imageY + imageHeight))
          {
            //left border
            if ( (x - i) >= imageX )
            {
              if (bitRead(Workspace[j][(x - i) / 8], ((x - i) % 8)))
              {
                wsX = (x - i);
                wsY = j;
                pointFound = true;
                /*
                Serial.print("I found:");
                Serial.print(wsX);
                Serial.print(",");
                Serial.println(wsY);
                */
                break;
              }
            }
            //Right border
            if ( (x + i) <= imageX + imageWidth )
            {
              if (bitRead(Workspace[j][(x + i) / 8], ((x + i) % 8)))
              {
                wsX = (x + i);
                wsY = j;
                pointFound = true;
                /*
                Serial.print("I found:");
                Serial.print(wsX);
                Serial.print(",");
                Serial.println(wsY);
                */
                break;
              }
            }
          }
        }
        if (pointFound)
          break;
      }
    }
    if (pointFound)
    {
      //Serial.println("I am moving to position");
      //wait until the last point was reached before moving on

      delay(MINMOVETIME);
      
      while ((millis() - timestamp) < MAXMOVETIME) 
      {

        if (abs(pivot.dvolt - pivot.cvolt) < 75 &&
             abs(shoulder.dvolt - shoulder.cvolt) < 25 &&
             abs(elbow.dvolt - elbow.cvolt) < 25)
        {
          break;
        }
        /*
        Serial.print(pivot.dvolt);
        Serial.print("-");
        Serial.println(pivot.cvolt);

        Serial.print(shoulder.dvolt);
        Serial.print("-");
        Serial.println(shoulder.cvolt);

        Serial.print(elbow.dvolt);
        Serial.print("-");
        Serial.println(elbow.cvolt);
        */
        pivot.cvolt = analogRead(pivot.fpin);
        shoulder.cvolt = analogRead(shoulder.fpin);
        elbow.cvolt = analogRead(elbow.fpin);
        
      }
    
      //we are at the correct spot, turn on the extruder
      if (!firstMove)
      {
        gripper.servo.writeMicroseconds(gripper.on);

        //wait for the extruder to start etruding
        if (!gripper.extruding)
        {
          delay(EXTRUSIONSTART);
          gripper.extruding = true;
        }
      }
      else
      {
        firstMove = false;
      }
    
      
    
      //if the distance to move is greater than 15mm turn off the extruder
      int distance = sqrt(pow(abs(wsX - x),2)+pow(abs(wsY - y),2));
      if (distance > 15)
      {
        gripper.servo.writeMicroseconds(gripper.off);
        delay(EXTRUSIONSTOP);
        gripper.extruding = false;
      }

      //make the move
      /*
      Serial.println("I am moving to:");
      Serial.print("x - ");
      Serial.println(wsX);
      Serial.print("y - ");
      Serial.println(wsY);
      Serial.print("z - ");
      Serial.println(imageZ);
      */
      x = wsX;
      y = wsY;
      moveArm(x,(WorkspaceY - y),imageZ);

      //clear the affected pixels 
      
      for (int i = y - 1; i < y + 2; i++)
      {
        for (int j = x - 1; j < x + 2; j++)
        {
          if( i >= imageY && i < (imageY+ imageHeight) && j >= imageX && j < (imageX + imageWidth))
          {
            bitClear(Workspace[i][j/8],(j%8));
          }
        }
      }
    } 
  }

  if (finishedLayer)
    Serial.write("Ready");
}

void doManualMoves()
{
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
      Serial.print(pivot.cfreq);
      Serial.print("\t");
      //Serial.print("S: ");
      //Serial.print(shoulder.cvolt);
      //Serial.print("\t");
      Serial.print(shoulder.cfreq);
      //Serial.print("\t");
      Serial.print("\t");
      //Serial.print("E: ");
      //Serial.print(elbow.cvolt);
      //Serial.print("\t");
      //Serial.print(" = ");
      Serial.println(elbow.cfreq);
    }
  }
}

void doRandomMoves()
{
  for (int samples = 200; samples > 0; samples--)
    {
      z = random(-80,100);
      
      int ymin = sqrt(pow(200,2) - pow(abs(z),2));
      int ymax = sqrt(pow(400,2) - pow(abs(z),2));
      y = random(ymin,ymax);

      int xmin = 400 - ymax;
      int xmax = 800 - xmin;
      x = random(xmin,xmax);
      
      moveArm(x,y,z);
      delay(2000);
      pivot.cvolt = analogRead(pivot.fpin);
      shoulder.cvolt = analogRead(shoulder.fpin);
      elbow.cvolt = analogRead(elbow.fpin);
      Serial.print(pivot.cfreq);
      Serial.print("\t");
      Serial.print(pivot.cvolt);
      Serial.print("\t");
      Serial.print(shoulder.cfreq);
      Serial.print("\t");
      Serial.print(shoulder.cvolt);
      Serial.print("\t");
      Serial.print(elbow.cfreq);
      Serial.print("\t");
      Serial.println(elbow.cvolt);
    }
    randomMoves = false;
}

void moveArm(double x, double y, double z)
{
  int xmin = 0;
  int ymin = 80;
  int zmin = -87;
  
  int xmax = 800;
  int ymax = 400;
  int zmax = 100;

  if (x > xmax)
    x = xmax;
  if (x < xmin)
    x = xmin;
    
  if (y > ymax)
    y = ymax;
  if (y < ymin)
    y = ymin;
  
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
  double d4r = 100;
  double d4z = 47;

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
  shoulder.cfreq = 610.82 * ThetaA + 568.89;
  elbow.cfreq = -616.26 * ThetaB + 1687;
  pivot.cfreq = 699.16 * ThetaR + 370.35;
  
  shoulder.servo.writeMicroseconds(shoulder.cfreq);
  elbow.servo.writeMicroseconds(elbow.cfreq);
  pivot.servo.writeMicroseconds(pivot.cfreq);

  //timestamp the motion in case of feedback failure.
  timestamp = millis();

  //Feedback formulas
  pivot.dvolt = 0.8031 * pivot.cfreq + 296.73;
  shoulder.dvolt = 0.7956 * shoulder.cfreq + 268.25;
  elbow.dvolt = 0.5424 * elbow.cfreq + 705.37;
  

  //update current voltage
  pivot.cvolt = analogRead(pivot.fpin);
  shoulder.cvolt = analogRead(shoulder.fpin);
  elbow.cvolt = analogRead(elbow.fpin);
  
}


