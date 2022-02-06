// Author: Dana Kleber
// File Name: Sphere.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a sphere subclass

using System;

class Sphere : ThreeDShape
{
  // store sphere info
  private double [] xPoints = new double [1];
  private double [] yPoints = new double [1];
  private double radius;
  private double depth;

  public Sphere(string colour, double [] xPoints, double [] yPoints, double radius, double depth) : base(colour)
  {
     for (int i = 0; i < xPoints.Length; i++)
    {
      this.xPoints[i] = xPoints[i];
    }

    for (int i = 0; i < yPoints.Length; i++)
    {
      this.yPoints[i] = yPoints[i];
    }

    this.radius = radius;
    this.depth = depth;
  }

  //Pre: None 
  //Post: x points of shape as a double
  //Desc: Retrieve x points of the shape
  public double [] GetXPoints()
  {
    return xPoints;
  }

  //Pre: None 
  //Post: y points of shape as a double
  //Desc: Retrieve y points of the shape
  public double [] GetYPoints()
  {
    return yPoints;
  }

  //Pre: None 
  //Post: radius of shape as a double
  //Desc: radius of of the shape
  public double GetRadius()
  {
    return radius;
  }

  //Pre: xpoints of shape as a double array
  //Post: None
  //Desc: modify the shapes x points
  public void SetXPoints(double [] xPoints)
  {
    this.xPoints = xPoints;
  }

  //Pre: ypoints of shape as a double array
  //Post: None
  //Desc: modify the shapes y points
  public void SetYPoints(double [] yPoints)
  {
    this.yPoints = yPoints;
  }

  //Pre: radius of shape as a double
  //Post: None
  //Desc: modify the shapes radius
  public void SetRadius(double radius)
  {
    this.radius = radius;
  }

  // Pre: none
  // Post: ap as a double
  // Description: assign anchor point 
  public override double AssignAnchorPointX()
  {
    anchorPointX = xPoints[0];
    anchorPointY = yPoints[0];
    return anchorPointX;
  }

  // Pre: none
  // Post: ap as a double
  // Description: assign anchor point 
  public override double AssignAnchorPointY()
  {
    anchorPointX = xPoints[0];
    anchorPointY = yPoints[0];
    return anchorPointY;
  }

  // Pre: none
  // Post: SA as a double
  // Description: calc surface area
  public override double CalcSurfaceArea()
  {
    surfaceArea = 4*(Math.PI * Math.Pow(radius,2));
    return surfaceArea;
  }
  
  // Pre: none
  // Post: volume as a double
  // Description: calc volume
  public override double CalcVolume()
  {
    volume = (4/3)*(Math.PI * Math.Pow(radius,3));
    return volume;
  }

  // Pre: none
  // Post: None
  // Description: display shapes
  public override void DisplayData()
  {
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
    Console.WriteLine("Shape type: Circle");
    Console.WriteLine("Dimensions: " + xPoints[0] + "," + yPoints[0]);
    Console.WriteLine("Anchor Point: " + anchorPointX + "," + anchorPointY);
    Console.WriteLine("Colour: " + colour);
  }
  
  // Pre: none
  // Post: None
  // Description: display extra shape data
  public override void DisplayExtraData()
  {
   surfaceArea = CalcSurfaceArea();
    volume = CalcVolume();
    DisplayData();
     Console.WriteLine("Surface area of sphere: " + Math.Round(surfaceArea, 2));
    Console.WriteLine("Volume of sphere: " + Math.Round(volume, 2));
  }

  // Pre: user point for x as a double and user point for y and z as a double
  // Post: None
  // Description: find collision
  public override void CollDetection(double userPointX, double userPointY, double userPointZ)
  {
    double length1;

    length1 = CalcLength(xPoints[0], userPointX, yPoints[0], userPointY);

    if (length1 <= radius && userPointZ <= depth)
    {
      Console.WriteLine("There is a collison");
    }
    else
    {
      Console.WriteLine("There isn't a collison");
    }
  }
  
  // Pre: none
  // Post: double array for x points
  // Description: copy x
  public override double [] PlaceShapeX()
  {
    double [] points = xPoints;
    return points;
  }
  
  // Pre: none
  // Post: double array for y points
  // Description: copy y
  public override double [] PlaceShapeY()
  {
    double [] points = yPoints;
    return points;
  }
 
}