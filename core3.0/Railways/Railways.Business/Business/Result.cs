using System;
using System.Net;

namespace Railways.Business.Business
{
    /// <summary>
    /// Represents value result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicates if result is successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Error code/>.
        /// </summary>
        public HttpStatusCode ErrorCode { get; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Indicates if result is failure.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// ctor.
        /// </summary>
        protected Result(bool isSuccess, HttpStatusCode errorCode, string message)
        {
            if (isSuccess && errorCode == HttpStatusCode.BadRequest)
                throw new InvalidOperationException();
            if (!isSuccess && errorCode == HttpStatusCode.BadRequest)
                throw new InvalidOperationException();

            if (isSuccess && message != string.Empty)
                throw new InvalidOperationException();
            if (!isSuccess && message == string.Empty)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Creates failure.
        /// </summary>
        public static Result<T> Fail<T>(HttpStatusCode errorCode, string message)
        {
            return new Result<T>(default(T), false, errorCode, message);
        }

        /// <summary>
        /// Creates failure.
        /// </summary>
        public static Result<T> Fail<T>(Result result)
        {
            return new Result<T>(default(T), false, result.ErrorCode, result.Message);
        }

        /// <summary>
        /// Creates failure.
        /// </summary>
        public static Result Fail(HttpStatusCode errorCode, string message)
        {
            return new Result(false, errorCode, message);
        }

        /// <summary>
        /// Creates successful result.
        /// </summary>
        public static Result Ok()
        {
            return new Result(true, HttpStatusCode.OK, string.Empty);
        }

        /// <summary>
        /// Creates successful result.
        /// </summary>
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, HttpStatusCode.OK, string.Empty);
        }
    }

    /// <summary>
    /// Describes value result or error.
    /// </summary>
    public class Result<T> : Result //, IResult<T>
    {
        private readonly T _value;

        /// <summary>
        /// Value in case of successful result.
        /// </summary>
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        /// <summary>
        /// ctor.
        /// </summary>
        protected internal Result(T value, bool isSuccess, HttpStatusCode errorCode, string message)
            : base(isSuccess, errorCode, message)
        {
            _value = value;
        }
    }
}