// Author: Dana Kleber
// File Name: Circle.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a circle subclass

using System;

class Circle : Shape
{
  // store circle info
  private double [] xPoints = new double [1];
  private double [] yPoints = new double [1];
  private double radius;

  public Circle(string colour, double [] xPoints, double [] yPoints, double radius) : base(colour)
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
  //Post: radius shape as a double
  //Desc: Retrieve radius of the shape
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
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointX()
  {
    anchorPointX = xPoints[0];
    anchorPointY = yPoints[0];
    return anchorPointX;
  }

  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointY()
  {
    anchorPointX = xPoints[0];
    anchorPointY = yPoints[0];
    return anchorPointY;
  }

  // Pre: none
  // Post: None
  // Description: calc area
  public override double CalcArea()
  {
    area = Math.PI * Math.Pow(radius,2);
    return area;
  }
 
  // Pre: none
  // Post: None
  // Description: calc perimeter
  public override double CalcPerimeter()
  {
    double diameter;
    
    diameter = radius + radius;

    perimeter = Math.PI * diameter;
    return perimeter;
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
    area = CalcArea();
    perimeter = CalcPerimeter();
    DisplayData();
    Console.WriteLine("Area of circle: " + Math.Round(area, 2));
    Console.WriteLine("Circumfrence of circle: " + Math.Round(perimeter, 2));
  }

  // Pre: user point for x as a double and user point for y as a double
  // Post: None
  // Description: find collision
  public override void CollDetection(double userPointX, double userPointY)
  {
    double length1;

    length1 = CalcLength(xPoints[0], userPointX, yPoints[0], userPointY);

    if (length1 <= radius)
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