﻿namespace Registration.Utilities
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult SuccessResult(string message)
        {
            return new OperationResult
            {
                Success = true,
                Message = message
            };
        }

        public static OperationResult FailureResult(string message)
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
            };
        }
    }
}
