using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Linq;

namespace DataTransfertObjects.Tests
{
    public class ValidationTests
    {
        public static readonly object[][] appUsersDto_With_One_Required_Field_Missing =
        {
            new object[] { "0efb9b00-e0de-4d2f-aa08-1b7f07b16129", null, "lastName", new DateTime(2017, 3, 1), "The FirstName field is required."  },
            new object[] { "0efb9b00-e0de-4d2f-aa08-1b7f07b16129", "", "lastName", new DateTime(2017, 3, 1), "The FirstName field is required."  },
            new object[] { "0efb9b00-e0de-4d2f-aa08-1b7f07b16129", "firstName", null, new DateTime(2017, 3, 1), "The LastName field is required."  },
            new object[] { "0efb9b00-e0de-4d2f-aa08-1b7f07b16129", "firstName", "", new DateTime(2017, 3, 1), "The LastName field is required."  },
            //new object[] { "0efb9b00-e0de-4d2f-aa08-1b7f07b16129", null, null, null, new DateTime(), "The FirstName field is required."  },
        };

        
        public static readonly object[][] itemCategoryDto_With_One_Required_Field_Missing =
        {
            new object[] { null, "Description", "The Name field is required." },
            new object[] { "", "Description", "The Name field is required." },
        };

        
        public static readonly object[][] itemDto_With_One_Required_Field_Missing =
        {
            new object[] { "", "Description", "SellerId", Guid.NewGuid(), "The Name field is required." },
            new object[] { null, "Description", "SellerId", Guid.NewGuid(), "The Name field is required." },

            new object[] { "Name", "Description", "", Guid.NewGuid(), "The SellerId field is required." },
            new object[] { "Name", "Description", null, Guid.NewGuid(), "The SellerId field is required." },

        };


        public static readonly object[][] orderDto_With_One_Required_Field_Missing =
        {
            new object[] { new DateTime(2017, 3, 1), 0, "", "The CustomerId field is required." },
            new object[] { new DateTime(2017, 3, 1), 0, null, "The CustomerId field is required." },
        };


        public static readonly object[][] orderItemDto_With_One_Required_Field_Missing =
        {
            new object[] { 0, 0, null, Guid.NewGuid(), "The OrderId field is required." },
        };



        [Theory, MemberData(nameof(appUsersDto_With_One_Required_Field_Missing))]
        public void IsValid_AppUsersDto_ReturnErrorMessage(string id, string firstName, string lastName, DateTime birthdate, string errorMessage)
        {
            //ACT
            var lstErrors = ValidateModel(new AppUsersDto() { Id =id, FirstName = firstName, LastName = lastName, Birthdate = birthdate });

            //ASSERT
            Assert.InRange(lstErrors.Count, 1, int.MaxValue);
            Assert.Matches(errorMessage, lstErrors.Where(x => x.ErrorMessage == errorMessage).First().ErrorMessage);
        }

       

        [Theory, MemberData(nameof(itemCategoryDto_With_One_Required_Field_Missing))]
        public void IsValid_ItemCategoryDto_ReturnErrorMessage(string name, string description, string errorMessage)
        {
            //ACT
            var lstErrors = ValidateModel(new ItemCategoriesDto() { Id = null, Name = name, Description = description });

            //ASSERT
            Assert.InRange(lstErrors.Count, 1, int.MaxValue);
            Assert.Matches(errorMessage, lstErrors.Where(x => x.ErrorMessage == errorMessage).First().ErrorMessage);
        }



        [Theory, MemberData(nameof(itemDto_With_One_Required_Field_Missing))]
        public void IsValid_ItemDto_ReturnErrorMessage(string name, string description, string sellerId, Guid itemCategoryId, string errorMessage)
        {
            //ACT
            var lstErrors = ValidateModel(new ItemsDto() { Id = null, Name = name, Description = description , SellerId = sellerId, ItemCategoryId = itemCategoryId});

            //ASSERT
            Assert.InRange(lstErrors.Count, 1, int.MaxValue);
            Assert.Matches(errorMessage, lstErrors.Where(x => x.ErrorMessage == errorMessage).First().ErrorMessage);
        }



        [Theory, MemberData(nameof(orderDto_With_One_Required_Field_Missing))]
        public void IsValid_OrderDto_ReturnErrorMessage(DateTime date, int total, string customerId, string errorMessage)
        {
            //ACT
            var lstErrors = ValidateModel(new OrdersDto() { Id = null, Date = date, Total = total , CustomerId = customerId});

            //ASSERT
            Assert.InRange(lstErrors.Count, 1, int.MaxValue);
            Assert.Matches(errorMessage, lstErrors.Where(x => x.ErrorMessage == errorMessage).First().ErrorMessage);
        }
        



        //http://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}

