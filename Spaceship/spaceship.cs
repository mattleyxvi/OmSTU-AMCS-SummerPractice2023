name Spaceship;
public class Spaceship
{
public static double[] Movement(double[] ShipCoordinates,double[] ShipWay, bool CanMove ){

        if (CanMove == false) {
            throw new System.Exception();
        }
        
        foreach(double x in ShipCoordinates.Concat(ShipWay).ToArray()){
            if (double.IsNaN(x) | double.IsInfinity(x)){
             throw new System.Exception();
            }    
        }
        

        for (int i = 0; i < ShipCoordinates.Length;i++){
            ShipCoordinates[i] += ShipWay[i];
        }

        return  ShipCoordinates;
        }

}
