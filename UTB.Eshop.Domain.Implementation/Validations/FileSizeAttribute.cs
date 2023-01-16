using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Eshop.Domain.Implementation.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field)]
    public class FileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        public long MaxByteSize { get; set; }
        public FileSizeAttribute(uint maxByteSize)
        {
            MaxByteSize = maxByteSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            IFormFile file = value as IFormFile;

            if (file is null)
                throw new NotImplementedException($"The {nameof(FileSizeAttribute)} is not implemented for type {value.GetType()}");

            long fileSize = file.OpenReadStream().Length;

            if (fileSize > MaxByteSize)
                return new ValidationResult($"File size {file}bytes is too big. Max allowed size is {MaxByteSize}bytes");

            return ValidationResult.Success;

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-size", "true");
            context.Attributes.Add("data-val-filesize", $"{context.ModelMetadata.Name}: max file size is {MaxByteSize} (client)");
            context.Attributes.Add("data-val-filesize-size", MaxByteSize.ToString());
        }
    }
}
