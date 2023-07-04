namespace Spaceship;
public class Spaceship
{
public static double[] Movement(double[] ShipCoordinates,double[] Direction, bool CanMove ){

        if (CanMove == false) {
            throw new System.Exception();
        }
        
        if (ShipCoordinates.Any(double.IsNaN) || Direction.Any(double.IsInfinity)){
         throw new System.Exception(); 
        }
        

        for (int i = 0; i < ShipCoordinates.Length;i++){
            ShipCoordinates[i] += Direction[i];
        }

        return  ShipCoordinates;
        }

}
