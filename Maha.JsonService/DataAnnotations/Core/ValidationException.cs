﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Maha.JsonService.DataAnnotations
{
    [Serializable]
    public class ValidationException: Exception
    {
        private ValidationResult _validationResult;

        public ValidationAttribute ValidationAttribute { get; private set; }

        public ValidationResult ValidationResult
        {
            get
            {
                if (this._validationResult == null)
                {
                    this._validationResult = new ValidationResult(this.Message);
                }
                return this._validationResult;
            }
        }

        public object Value { get; private set; }

        public ValidationException(ValidationResult validationResult, ValidationAttribute validatingAttribute, object value)
            : this(validationResult.ErrorMessage, validatingAttribute, value)
        {
            this._validationResult = validationResult;
        }

        public ValidationException(string errorMessage, ValidationAttribute validatingAttribute, object value)
            : base(errorMessage)
        {
            this.Value = value;
            this.ValidationAttribute = validatingAttribute;
        }

        public ValidationException()
            : base()
        {
        }

        public ValidationException(string message)
            : base(message) { }

       
        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
