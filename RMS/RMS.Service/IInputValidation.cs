namespace RMS.Service
{ 
    /// <summary>
    /// handles validation
    /// </summary>
    public interface IInputValidation 
    {
  
        bool Validate(int[][] searchGrid, int adjacentIntegers);
    }
}