// Author: Dana Kleber
// File Name: Line.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a line subclass

using System;

class Line : Shape
{
  // store line info
  private double [] xPoints = new double [2];
  private double [] yPoints = new double [2];
  
  // store line calculations
  private double slope;
  private double lineLength;

  public Line(string colour, double [] xPoints, double [] yPoints) : base(colour)
  {
    for (int i = 0; i < xPoints.Length; i++)
    {
      this.xPoints[i] = xPoints[i];
    }

    for (int i = 0; i < yPoints.Length; i++)
    {
      this.yPoints[i] = yPoints[i];
    }
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
  //Post: slope of shape as a double
  //Desc: Retrieve slope of the shape
  public double GetSlope()
  {
    return slope;
  }

  //Pre: None 
  //Post: length of shape as a double
  //Desc: Retrieve length of the shape
  public double GetLineLength()
  {
    return lineLength;
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

  //Pre: length of shape as a double
  //Post: None
  //Desc: modify the shapes length
  public void SetLineLength(double lineLength)
  {
    this.lineLength = lineLength;
  }

  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointX()
  {
    if (xPoints[0] < xPoints[1])
    {
      anchorPointX = xPoints[0];
    }
    else if (xPoints[1] < xPoints[0])
    {
      anchorPointX = xPoints[1];
    }

    if (yPoints[0] < yPoints[1])
    {
      anchorPointY = yPoints[0];
    }
    else if (xPoints[1] < xPoints[0])
    {
      anchorPointY = yPoints[1];
    }
    return anchorPointX;
  }

  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointY()
  {
    if (xPoints[0] < xPoints[1])
    {
      anchorPointX = xPoints[0];
    }
    else if (xPoints[1] < xPoints[0])
    {
      anchorPointX = xPoints[1];
    }

    if (yPoints[0] < yPoints[1])
    {
      anchorPointY = yPoints[0];
    }
    else if (xPoints[1] < xPoints[0])
    {
      anchorPointY = yPoints[1];
    }
    return anchorPointY;
  }

  // Pre: none
  // Post: slope as double
  // Description: calculate slope
  public double CalcSlope()
  {
    slope = (yPoints[1] - yPoints[0])/(xPoints[1] - xPoints[0]);
    return slope;
  }
  
  // Pre: none
  // Post: None
  // Description: display shapes
  public override void DisplayData()
  {
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
    Console.WriteLine("Shape type: Line");
    Console.WriteLine("Dimensions: " + xPoints[0] + "," + yPoints[0] + " & " + xPoints[1] + "," + yPoints[1]);
    Console.WriteLine("Anchor Point: " + anchorPointX + "," + anchorPointY);
    Console.WriteLine("Colour: " + colour);
  }
  
  // Pre: none
  // Post: None
  // Description: display extra shape data
  public override void DisplayExtraData()
  {
    slope = CalcSlope();
    DisplayData();
    Console.WriteLine("Length of line: " + Math.Round(CalcLength(xPoints[0], xPoints[1], yPoints[0], yPoints[1]),2));
    Console.WriteLine("Slope of line: " + Math.Round(slope ,2));
  }

  // Pre: user point for x as a double and user point for y as a double
  // Post: None
  // Description: find collision
  public override void CollDetection(double userPointX, double userPointY)
  {
    double length1;
    double length2;
    double sum;

    length1 = CalcLength(xPoints[0], userPointX, yPoints[0], userPointY);
    length2 = CalcLength(xPoints[1], userPointX, yPoints[1], userPointY);

    sum = length1 + length2;
    
    if (sum == (CalcLength(xPoints[0], xPoints[1], yPoints[0], yPoints[1])))
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