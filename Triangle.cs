// Author: Dana Kleber
// File Name: Triangle.cs
// Project Name: pass2
// Creation Date: Oct. 25, 2020
// Modified Date: Nov. 1, 2020
// Description: This program is built to make a triangle subclass

using System;

class Triangle : Shape
{
  // store triangle info
  private double [] xPoints = new double [3];
  private double [] yPoints = new double [3];
  
  // store triangle calcualtions
  private double [] triLengths = new double [3];
  private double triBase;
  private double triHeight;
  private double triDiagonalLength;
  

  public Triangle(string colour, double [] xPoints, double [] yPoints) : base(colour)
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
  //Post: lengths of shape as a double
  //Desc: Retrieve lengths of the shape
  public double [] GetTriLengths()
  {
    return triLengths;
  }

  //Pre: None 
  //Post: base of shape as a double
  //Desc: Retrieve base of the shape
  public double GetTriBase()
  {
    return triBase;
  }

  //Pre: None 
  //Post:height of shape as a double
  //Desc: Retrieve height of the shape
  public double GetTriHeight()
  {
    return triHeight;
  }

  //Pre: None 
  //Post: diagonal of shape as a double
  //Desc: Retrieve digoanl of the shape
  public double GetTriDiagonalLength()
  {
    return triDiagonalLength;
  }

   //Pre: xpoints of shape as a double array
  //Post: None
  //Desc: modify the shapes x points
  public void SetXPoints(double [] xPoints)
  {
    this.xPoints = xPoints;
  }

  //Pre: xpoints of shape as a double array
  //Post: None
  //Desc: modify the shapes x points
  public void SetYPoints(double [] yPoints)
  {
    this.yPoints = yPoints;
  }

  //Pre: lengths of shape as a double array
  //Post: None
  //Desc: modify the shapes legnths
  public void SetTriLengths(double [] triLengths)
  {
    this.triLengths= triLengths;
  }

  //Pre: base of shape as a double 
  //Post: None
  //Desc: modify the shapes base
  public void SetTriBase(double triBase)
  {
    this.triBase = triBase;
  }

  //Pre: height of shape as a double 
  //Post: None
  //Desc: modify the shapesheight
  public void SetTriHeight(double triHeight)
  {
    this.triHeight = triHeight;
  }

  //Pre: diaongal length of shape as a double
  //Post: None
  //Desc: modify the shapes diaongal length
  public void SetTriDiagonalLength(double triDiagonalLength)
  {
    this.triDiagonalLength = triDiagonalLength;
  }

  // Pre: none
  // Post: anchor point as double
  // Description: assign anchor point
  public override double AssignAnchorPointX()
  {
    if (yPoints[0] <= yPoints[1] && yPoints[0] <= yPoints[2])
    {
      if (xPoints[0] <= xPoints[1] && xPoints[0] <= xPoints[2])
      {
        anchorPointX = xPoints[0];
        anchorPointY = yPoints[0];
      }
    }

    if (yPoints[1] <= yPoints[0] && yPoints[1] <= yPoints[2])
    {
      if (xPoints[1] <= xPoints[0] && xPoints[1] <= xPoints[2])
      {
        anchorPointX = xPoints[1];
        anchorPointY = yPoints[1];
      }
    }
    return anchorPointX;
  }

  // Pre: none
  // Post: anchor point as a dobule
  // Description: assign anchor point
    public override double AssignAnchorPointY()
  {
    if (yPoints[0] <= yPoints[1] && yPoints[0] <= yPoints[2])
    {
      if (xPoints[0] <= xPoints[1] && xPoints[0] <= xPoints[2])
      {
        anchorPointX = xPoints[0];
        anchorPointY = yPoints[0];
        
      }
    }

    if (yPoints[1] <= yPoints[0] && yPoints[1] <= yPoints[2])
    {
      if (xPoints[1] <= xPoints[0] && xPoints[1] <= xPoints[2])
      {
        anchorPointX = xPoints[1];
        anchorPointY = yPoints[1];
        
      }
    }
  

    if (yPoints[2] <= yPoints[1] && yPoints[2] <= yPoints[0])
    {
      if (xPoints[2] <= xPoints[1] && xPoints[2] <= xPoints[0])
      {
        anchorPointX = xPoints[2];
        anchorPointY = yPoints[2];
      }
    }   
    return anchorPointY;
  }

  // Pre: none
  // Post: base as a double
  // Description: assign base
  public double AssignBase()
  {
    AssignAnchorPointX();
    AssignAnchorPointY();
  
    for (int i = 0; i < xPoints.Length; i++)
    {
    if (anchorPointY == yPoints[i] && (anchorPointX != xPoints[i]))
    {
      triBase = CalcLength(anchorPointX, xPoints[i], anchorPointY, yPoints[i]);
    }
    }
    return triBase;
  }

  // Pre: none
  // Post: height as a double
  // Description: assign height
  public double AssignHeight()
  {
    double hpX;
    double hpY;
   // double triHeight;
    if (yPoints[0] > yPoints[1] && yPoints[0] > yPoints[2])
    {
      hpX = xPoints[0];
      hpY = yPoints[1];

      triHeight = CalcLength(hpX, xPoints[0], hpY, yPoints[0]);
    }
    if (yPoints[1] > yPoints[0] && yPoints[1] > yPoints[2])
    {
      hpX = xPoints[1];
      hpY = yPoints[2];

      triHeight = CalcLength(hpX, xPoints[1], hpY, yPoints[1]);
    }
    if (yPoints[2] > yPoints[1] && yPoints[2] > yPoints[0])
    {
      hpX = xPoints[2];
      hpY = yPoints[1];

      triHeight = CalcLength(hpX, xPoints[2], hpY, yPoints[2]);
    }
   return triHeight;
  }

  // Pre: none
  // Post: None
  // Description: calc area
  public override double CalcArea()
  { 
    triBase = AssignBase();
    triHeight = AssignHeight();
    area = (triBase * triHeight) / 2;
    return area;
  }

  // Pre: none
  // Post: None
  // Description: calc perimeter
  public override double CalcPerimeter()
  {
    triLengths[0] = CalcLength(xPoints[0], xPoints[1], yPoints[0], yPoints[1]);
    triLengths[1] = CalcLength(xPoints[0], xPoints[2], yPoints[0], yPoints[2]);
    triLengths[2] = CalcLength(xPoints[1], xPoints[2], yPoints[1], yPoints[2]);

    perimeter = triLengths[0] + triLengths[1] + triLengths[2];

    return perimeter;
  }

  // Pre: none
  // Post: None
  // Description: display shapes
  public override void DisplayData()
  {
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
    triLengths[0] = CalcLength(xPoints[0], xPoints[1], yPoints[0], yPoints[1]);
    triLengths[1] = CalcLength(xPoints[0], xPoints[2], yPoints[0], yPoints[2]);
    triLengths[2] = CalcLength(xPoints[1], xPoints[2], yPoints[1], yPoints[2]);
    Console.WriteLine("Shape type: Triangle");
    Console.WriteLine("Dimensions: " + triLengths[0] + ", " + triLengths[1] + ", " + triLengths[2]);
    Console.WriteLine("Anchor Point: " + anchorPointX + "," + anchorPointY);
    Console.WriteLine("Colour: " + colour);
  }

  // Pre: none
  // Post: None
  // Description: display extra shape data
  public override void DisplayExtraData()
  {
    anchorPointX = AssignAnchorPointX();
    anchorPointY = AssignAnchorPointY();
    triLengths[0] = CalcLength(xPoints[0], xPoints[1], yPoints[0], yPoints[1]);
    triLengths[1] = CalcLength(xPoints[0], xPoints[2], yPoints[0], yPoints[2]);
    triLengths[2] = CalcLength(xPoints[1], xPoints[2], yPoints[1], yPoints[2]);
    triBase = AssignBase();
    triHeight = AssignHeight();
    area = CalcArea();
    perimeter = CalcPerimeter();
    DisplayData();
    Console.WriteLine(triBase);
    Console.WriteLine("Area of triangle: " + Math.Round(area, 2));
    Console.WriteLine("Perimeter of triangle: " + Math.Round(perimeter, 2));
  }

  // Pre: length a,b,and c as doubles
  // Post: length as a double
  // Description: calculate length with herons formula
  public double HeronsFormula(double lengthA, double lengthB, double lengthC)
  {
    double sp;
    double areaHerons;

    sp = (lengthA + lengthB + lengthC) / 2;
    areaHerons = Math.Sqrt(sp * (sp - lengthA) * (sp - lengthB) * (sp - lengthC));

    return areaHerons;
  }

  // Pre: user point for x as a double and user point for y as a double
  // Post: None
  // Description: find collision
  public override void CollDetection(double userPointX, double userPointY)
  {
    double length1;
    double length2;
    double length3;

    double area1;
    double area2;
    double area3;

    double sum;

    length1 = CalcLength(xPoints[0], userPointX, yPoints[0], userPointY);
    length2 = CalcLength(xPoints[1], userPointX, yPoints[1], userPointY);
    length3 = CalcLength(xPoints[2], userPointX, yPoints[2], userPointY);

    area1 = HeronsFormula(length1, length2, triLengths[0]);
    area2 = HeronsFormula(length1, length3, triLengths[1]);
    area3 = HeronsFormula(length2, length3, triLengths[2]);

    sum = area1 + area2 + area3;
    
    if (sum == area)
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