namespace RMS.Service
{
    /// <summary>
    /// Concreate class to handle or extend validation.
    /// </summary>
    public class InputValidator : IInputValidation
    {
        private string _errorMessage = string.Empty;
      

        public bool Validate(int[][] array , int adjacentNumber)
        {
            if (array.GetLength(0) == 0)
            {
                _errorMessage = "X dimensional Array cannot be empty";
                return false;
            }

            foreach (var x in array)
            {
                if (x == null)
                {
                    _errorMessage = "Input was not initialised.";
                    return false;
                }
                
            }

            return true;
        }

        public override string ToString()
        {
            return _errorMessage;
        }
    }
}