// Author: Dana Kleber
// File Name: Rec.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a rec subclass

using System;

class Rec : Shape
{
  // Store rectangle info
  private double [] xPoints = new double [1];
  private double [] yPoints = new double [1];
  private double recLength;
  private double recWidth;
  
  // Store rectangle calculations
  private double [] extraXPoints = new double [4];
  private double [] extraYPoints = new double [4];
  private double recDiagonalLength;
  
  public Rec(string colour, double [] xPoints, double [] yPoints, double recLength, double recWidth) : base(colour)
  {
   
    for (int i = 0; i < xPoints.Length; i++)
    {
      this.xPoints[i] = xPoints[i];
    }

    for (int i = 0; i < yPoints.Length; i++)
    {
      this.yPoints[i] = yPoints[i];
    }

    this.recLength = recLength;
    this.recWidth = recWidth;
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
  //Post: length of shape as a double
  //Desc: Retrieve lenght of the shape
  public double GetRecLength()
  {
    return recLength;
  }

  //Pre: None 
  //Post: width of shape as a double
  //Desc: Retrieve width of the shape
  public double GetRecWidth()
  {
    return recWidth;
  }

  //Pre: None 
  //Post: extra xpoints of shape as a double
  //Desc: Retrieve extra x points of the shape
  public double [] GetExtraXPoints()
  {
    return extraXPoints;
  }

  //Pre: None 
  //Post: extra y points of shape as a double
  //Desc: Retrieve extra y points of the shape
  public double [] GetExtraYPoints()
  {
    return extraYPoints;
  }

  //Pre: None 
  //Post: diaognal length of shape as a double
  //Desc: Retrieve diagonal length of the shape
  public double GetRecDiagonalLength()
  {
    return recDiagonalLength;
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
  public void SetRecLength(double recLength)
  {
    this.recLength= recLength;
  }

  //Pre: width of shape as a double 
  //Post: None
  //Desc: modify the shapes width 
  public void SetRecWidth(double recWidth)
  {
    this.recWidth = recWidth;
  }

  //Pre: extra x points of shape as a double array
  //Post: None
  //Desc: modify the shapes extra x points
  public void SetExtraXPoints(double [] extraXPoints)
  {
    this.extraXPoints = extraXPoints;
  }

  //Pre: extra ypoints of shape as a double array
  //Post: None
  //Desc: modify the shapes etra y points
  public void SetExtraYPoints(double [] extraYPoints)
  {
    this.extraYPoints = extraYPoints;
  }
  
  //Pre: diagonal length of shape as a double
  //Post: None
  //Desc: modify the shapes diaognal length
  public void SetRecDiagonalLength(double recDiagonalLength)
  {
    this.recDiagonalLength = recDiagonalLength;
  }

  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointX()
  {
   extraXPoints = AssignExtraPointsShapeX(xPoints);
    anchorPointX = extraXPoints[0];
    return anchorPointX;
  }
   
  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point 
  public override double AssignAnchorPointY()
  {
   extraYPoints = AssignExtraPointsShapeY(yPoints);
   // anchorPointY = yPoints[0];
    anchorPointY = extraYPoints[0];
    return anchorPointY;
  }

  // Pre: none
  // Post: None
  // Description: calc area
  public override double CalcArea()
  {
    area = recLength * recWidth;
    return area;
  }

  // Pre: none
  // Post: None
  // Description: calc perimeter
  public override double CalcPerimeter()
  {
    perimeter = (recLength * 2) + (recWidth * 2);
    return perimeter;
  }

  // Pre: none
  // Post: None
  // Description: display shapes
  public override void DisplayData()
  {
   anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
    Console.WriteLine("Shape type: Rectangle");
    Console.WriteLine("Dimensions: " + recLength + "," + recWidth);
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
    recDiagonalLength = CalcDiagonal(recLength, recWidth);
    DisplayData();
    Console.WriteLine("Area of rectangle: " + Math.Round(area, 2));
    Console.WriteLine("Perimeter of rectangle: " + Math.Round(perimeter, 2));
    Console.WriteLine("Diagonal: " + recDiagonalLength);
  }
 
  //Pre: x points as a double array
  // Post: x points as a double array
  // Description: assign extra points to rec
  public override double [] AssignExtraPointsShapeX(double [] xPoints)
  {
    extraXPoints[0] = xPoints[0];
    extraXPoints[1] = xPoints[0];
    extraXPoints[2] = xPoints[0] + recWidth;
    extraXPoints[3] = xPoints[0] + recWidth;

    return extraXPoints;
  }


  //Pre: y points as a double array
  // Post: y points as a double array
  // Description: assign extra points to rec
  public override double [] AssignExtraPointsShapeY(double [] yPoints)
  {
    extraYPoints[0] = yPoints[0];
    extraYPoints[1] = yPoints[0] - recLength;
    extraYPoints[2] = yPoints[0];
    extraYPoints[3] = yPoints[0] - recLength;

    return extraYPoints;
  }

  // Pre: x points as a double array and user translation for x as a double
  // Post: None
  // Description: translate shape by x
  public override void TranslateX(double [] extraXPoints, double userTransX)
  {
    for (int i = 0; i < xPoints.Length; i++)
    { 
      xPoints[i] = xPoints[i] + userTransX;
    }
     extraXPoints = AssignExtraPointsShapeX(xPoints); 

    for (int i = 0; i < extraXPoints.Length; i++)
    { 
      extraXPoints[i] = extraXPoints[i] + userTransX;
    }  
  }
  
  // Pre: y points as a double array and user translation for y as a double
  // Post: None
  // Description: translate shape by y
  public override void TranslateY(double [] extraYPoints, double userTransY)
  {
    for (int i = 0; i < yPoints.Length; i++)
    { 
      yPoints[i] = yPoints[i] + userTransY;
    }
     extraYPoints = AssignExtraPointsShapeY(yPoints); 
     
    for (int i = 0; i < extraYPoints.Length; i++)
    { 
      extraYPoints[i] = extraYPoints[i] + userTransY;
    }  
  }

  // Pre: x points as a double array and user points for y as a double, and scale factor as a double
  // Post: None
  // Description: scale shape
  public override void Scale(double [] xPoints, double [] yPoints, double scaleFactor)
  {
    for (int i = 0; i < extraXPoints.Length; i++)
    {
      extraXPoints[i] = extraXPoints[i] - anchorPointX;
      extraXPoints[i] = extraXPoints[i] * scaleFactor;
      extraXPoints[i] = extraXPoints[i] + anchorPointX;
    }
    for (int i = 0; i < extraYPoints.Length; i++)
    {
      extraYPoints[i] = extraYPoints[i] - anchorPointY;
      extraYPoints[i] = extraYPoints[i] * scaleFactor;
      extraYPoints[i] = extraYPoints[i] + anchorPointY;
    }
  }

  // Pre: index as an integer, user point for x as a double and user point for y as a double
  // Post: None
  // Description: find collision
  public override void CollDetection(double userPointX, double userPointY)
  {
    if (userPointX >= extraXPoints[0] && userPointX <= extraXPoints[2] && userPointY >= extraXPoints[0] && userPointY <= extraYPoints[1])
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
    double [] points = extraXPoints;
   
    return points;
  }

  // Pre: none
  // Post: double array for y points
  // Description: copy y
  public override double [] PlaceShapeY()
  {
    double [] points = extraYPoints;
   
    return points;
  }
 







}
