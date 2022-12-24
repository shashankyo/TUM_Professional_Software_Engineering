using System.Threading;
class Helpers
{
    Random rand = new Random();
    public bool CurrentSwitchState()   // method
    {
        int random_number = rand.Next(0, 2);
        if (random_number == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
            

        
    }
    public void Sleep(int amount)
    {
        Thread.Sleep(amount);
    }

}