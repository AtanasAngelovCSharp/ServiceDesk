namespace ServiceDesk.Common;

public static class ValidationConstants
{
    public const int CustomerFullNameMinLength = 3;
    public const int CustomerFullNameMaxLength = 100;
    public const int PhoneNumberMinLength = 7;
    public const int PhoneNumberMaxLength = 20;
    public const int EmailMaxLength = 100;
    public const int AddressMaxLength = 200;

    public const int DeviceBrandMaxLength = 50;
    public const int DeviceModelMaxLength = 50;
    public const int SerialNumberMaxLength = 50;

    public const int TechnicianFullNameMinLength = 3;
    public const int TechnicianFullNameMaxLength = 100;
    public const int SpecializationMaxLength = 50;

    public const int RequestTitleMinLength = 2;
    public const int RequestTitleMaxLength = 100;
    public const int ProblemDescriptionMinLength = 10;
    public const int ProblemDescriptionMaxLength = 1000;
    public const double EstimatedPriceMinValue = 0;
    public const double EstimatedPriceMaxValue = 10000;
}