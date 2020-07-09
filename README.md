# RangeFilter
This is a simple library for that focuses on a range of values, in particular struct values. 

## How it works
The class `RangeFilter<T>` contains properties `To` and `From` of type `T`. This can be used in models and ValueObjects mostly as request objects where there is need to have data entered with a certain range. 

### Example
Supposing you have a list of items in a database, each with property DateCreated:

```Csharp
public class Item
{
    public Guid Id {get; set;}

    public string Name {get; set;}

    public DateTime DateCreated {get; set;}
}
```

A method with to query for items in a range could be written as below;

```Csharp
public IList<Items> GetItems(DateTime from, DateTime to)
{
    //write code here...
}
```

With the RangeFilter however, these two parameters can now be encapsulated in one call as follows;
```Csharp
public IList<Items> GetItems(RangeFilter<DateTime> dateRange)
{
    DateTime from = dateRange.From;
    DateTime to = dateRange.To;

    //more code here...
}
```

### Validation
For those interested in having a validaiton on the Range filter, [FluentValidation](https://fluentvalidation.net/) has been used to ensure that the To value is greater than From value.

The validation can be implemented by calling on the RangeFilterValidator method as follows;
```Csharp
public IList<Items> GetItems(RangeFilter<DateTime> dateRange)
{
    RangeFilterValidator validator = new RangeFilterValidator<DateTime>();
    FluentValidation.Results.ValidationResult validation = validator.Validate(dateRange);

    if(!validation.IsValid()){
        //deal with the invalid scenario here
    }
    
    //otherwise continue here
    DateTime from = dateRange.From;
    DateTime to = dateRange.To;

    //more code here...
}
```
