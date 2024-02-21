namespace Sharping
{
    public class Operators
    {

        public void Temp() 
        {
            var cenas = new StringReader("example");

            if (cenas is null) 
            {
                cenas = new StringReader("another");
            }

            cenas ??= new StringReader("");
        }
    }
}
