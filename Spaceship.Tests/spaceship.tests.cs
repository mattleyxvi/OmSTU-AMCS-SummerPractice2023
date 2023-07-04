namespace SpaceshipTests;
using TechTalk.SpecFlow;
using Spaceship;

[Binding]
public class Spaceship_Tests
{
    public double[] spaceShipCordinates = new double[]{double.NaN, double.NaN};
    public double[] spaceShipSpeed = new double[]{double.NaN, double.NaN};
    public double[] actual = new double[]{double.NaN, double.NaN};
    public bool oportunity = true;
    public Exception actualException = new Exception();

	[Given(@"^космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void КоординатыКорабляВТочке(double x, double y)
    { 
        spaceShipCordinates[0] = x;
        spaceShipCordinates[1] = y;    
    }

    [Given(@"^космический корабль, положение в пространстве которого невозможно определить")]
    public void КоординатыКорабляОпределитьНевозможно(){}

    [Given(@"^имеет мгновенную скорость \((.*), (.*)\)")]
    public void СкоростьКорабля(double x, double y)
    { 
        spaceShipSpeed[0] = x;
        spaceShipSpeed[1] = y;    
    }

    [Given(@"^скорость корабля определить невозможно")]
    public void СкоростьКорабля(){}

    [Given(@"^изменить положение в пространстве космического корабля невозможно")]
    public void ПеремещениеНевозможно()
    { 
        oportunity = false;    
    }

    [When(@"^происходит прямолинейное равномерное движение без деформации")]
    public void ДвижениеКорабля(){
        try{
            actual = Spaceship.Movement(spaceShipCordinates, spaceShipSpeed, oportunity);
        }
        catch(Exception e){
            actualException = e;
        }
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void КосмическийКорабльПеремещаетсяВТочкуПространства(double x, double y)
    {
        double[] expectedResult = new double[]{x, y};

        for (int i = 0; i < expectedResult.Length;i++){
                Assert.Equal(expectedResult[i], actual[i], 6);
            }
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибка()
    {
        Assert.ThrowsAsync<Exception>(() => throw actualException);
    }
}