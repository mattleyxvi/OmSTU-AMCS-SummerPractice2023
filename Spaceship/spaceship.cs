namespace Spaceship;
public class Spaceship
{
    public static double[] Movement(double[] ShipCoordinates,double[] Direction, bool CanMove ){

        if (ShipCoordinates.Any(double.IsNaN) || Direction.Any(double.IsInfinity)|| CanMove == false){
         throw new System.Exception(); 
        }

        for (int i = 0; i < ShipCoordinates.Length;i++){
            ShipCoordinates[i] += Direction[i];
        }

        return  ShipCoordinates;
        }

    public static double UseFuel(double fuelBalance ,double fuelNeed){
        if(fuelNeed>fuelBalance){
            throw new System.Exception();
        }
        return fuelBalance-fuelNeed;
    }

    public static double Rotation (double degX,double instantSpeed,bool rotate){
    double[] currency = new double[]{degX,instantSpeed};
    if (currency.Any(double.IsNaN) || currency.Any(double.IsInfinity)|| rotate == false)
        throw new System.Exception(); 
    
    return degX + instantSpeed;
    }

}
