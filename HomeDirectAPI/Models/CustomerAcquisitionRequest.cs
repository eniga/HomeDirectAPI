using System;
using System.Collections.Generic;

namespace HomeDirectAPI.Models
{
    public class CustomerAcquisitionRequest
    {
        public Options Options { get; set; }
        public Application Application { get; set; }
        public ClientData ClientData { get; set; }
        public List<KeyPerson> KeyPersons { get; set; }
        public BusinessEntity BusinessEntity { get; set; }
        public SpareInputFields SpareInputFields { get; set; }
        public UpfrontServices UpfrontServices { get; set; }
    }

    public class UpfrontServices
    {
        public string WasEdqCalled { get; set; }
        public string WasIdiqCalled { get; set; }
        public string WasMitekCalled { get; set; }
        public string WasBusinessTargetCalled { get; set; }
        public BankWizard BankWizard { get; set; }
    }

    public class BankWizard
    {
        public string WasBankWizardCalled { get; set; }
        public ValidateResponse ValidateResponse { get; set; }
    }

    public class ValidateResponse
    {
        public string BBAN1 { get; set; }
        public string BBAN2 { get; set; }
        public string IBAN { get; set; }
        public long ConditionCount { get; set; }
        public List<Condition> Conditions { get; set; }
    }

    public class Condition
    {
        public string Severity { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class SpareInputFields
    {
        public string Spare_01_String_Length_1 { get; set; }
        public string Spare_02_String_Length_1 { get; set; }
        public string Spare_03_String_Length_1 { get; set; }
        public string Spare_04_String_Length_1 { get; set; }
        public string Spare_05_String_Length_1 { get; set; }
        public string Spare_06_String_Length_1 { get; set; }
        public string Spare_07_String_Length_1 { get; set; }
        public string Spare_08_String_Length_1 { get; set; }
        public string Spare_09_String_Length_1 { get; set; }
        public string Spare_10_String_Length_1 { get; set; }
        public string Spare_11_String_Length_5 { get; set; }
        public string Spare_12_String_Length_5 { get; set; }
        public string Spare_13_String_Length_5 { get; set; }
        public string Spare_14_String_Length_5 { get; set; }
        public string Spare_15_String_Length_5 { get; set; }
        public string Spare_16_String_Length_5 { get; set; }
        public string Spare_17_String_Length_5 { get; set; }
        public string Spare_18_String_Length_5 { get; set; }
        public string Spare_19_String_Length_5 { get; set; }
        public string Spare_20_String_Length_5 { get; set; }
        public string Spare_21_String_Length_10 { get; set; }
        public string Spare_22_String_Length_10 { get; set; }
        public string Spare_23_String_Length_10 { get; set; }
        public string Spare_24_String_Length_10 { get; set; }
        public string Spare_25_String_Length_10 { get; set; }
        public string Spare_26_String_Length_10 { get; set; }
        public string Spare_27_String_Length_10 { get; set; }
        public string Spare_28_String_Length_10 { get; set; }
        public string Spare_29_String_Length_10 { get; set; }
        public string Spare_30_String_Length_10 { get; set; }
        public string Spare_31_String_Length_30 { get; set; }
        public string Spare_32_String_Length_30 { get; set; }
        public string Spare_33_String_Length_30 { get; set; }
        public string Spare_34_String_Length_30 { get; set; }
        public string Spare_35_String_Length_30 { get; set; }
        public string Spare_36_String_Length_30 { get; set; }
        public string Spare_37_String_Length_30 { get; set; }
        public string Spare_38_String_Length_30 { get; set; }
        public string Spare_39_String_Length_30 { get; set; }
        public string Spare_40_String_Length_30 { get; set; }
        public string Spare_41_String_Length_50 { get; set; }
        public string Spare_42_String_Length_50 { get; set; }
        public string Spare_43_String_Length_50 { get; set; }
        public string Spare_44_String_Length_50 { get; set; }
        public string Spare_45_String_Length_50 { get; set; }
        public string Spare_46_String_Length_50 { get; set; }
        public string Spare_47_String_Length_50 { get; set; }
        public string Spare_48_String_Length_50 { get; set; }
        public string Spare_49_String_Length_50 { get; set; }
        public string Spare_50_String_Length_50 { get; set; }
        public string Spare_51_String_Length_100 { get; set; }
        public string Spare_52_String_Length_100 { get; set; }
        public string Spare_53_String_Length_100 { get; set; }
        public string Spare_54_String_Length_100 { get; set; }
        public string Spare_55_String_Length_100 { get; set; }
        public string Spare_56_Date { get; set; }
        public string Spare_57_Date { get; set; }
        public string Spare_58_Date { get; set; }
        public string Spare_59_Date { get; set; }
        public string Spare_60_Date { get; set; }
        public long Spare_61_Numeric { get; set; }
        public long Spare_62_Numeric { get; set; }
        public long Spare_63_Numeric { get; set; }
        public long Spare_64_Numeric { get; set; }
        public long Spare_65_Numeric { get; set; }
        public long Spare_66_Numeric { get; set; }
        public long Spare_67_Numeric { get; set; }
        public long Spare_68_Numeric { get; set; }
        public long Spare_69_Numeric { get; set; }
        public long Spare_70_Numeric { get; set; }
        public long Spare_71_Numeric { get; set; }
        public long Spare_72_Numeric { get; set; }
        public long Spare_73_Numeric { get; set; }
        public long Spare_74_Numeric { get; set; }
        public long Spare_75_Numeric { get; set; }
        public long Spare_76_Numeric { get; set; }
        public long Spare_77_Numeric { get; set; }
        public long Spare_78_Numeric { get; set; }
        public long Spare_79_Numeric { get; set; }
        public long Spare_80_Numeric { get; set; }
        public long Spare_81_Decimal { get; set; }
        public long Spare_82_Decimal { get; set; }
        public long Spare_83_Decimal { get; set; }
        public long Spare_84_Decimal { get; set; }
        public long Spare_85_Decimal { get; set; }
        public long Spare_86_Decimal { get; set; }
        public long Spare_87_Decimal { get; set; }
        public long Spare_88_Decimal { get; set; }
        public long Spare_89_Decimal { get; set; }
        public long Spare_90_Decimal { get; set; }
        public long Spare_91_Decimal { get; set; }
        public long Spare_92_Decimal { get; set; }
        public long Spare_93_Decimal { get; set; }
        public long Spare_94_Decimal { get; set; }
        public long Spare_95_Decimal { get; set; }
        public long Spare_96_Decimal { get; set; }
        public long Spare_97_Decimal { get; set; }
        public long Spare_98_Decimal { get; set; }
        public long Spare_99_Decimal { get; set; }
        public long Spare_100_Decimal { get; set; }
    }

    public class BusinessEntity
    {
        public string BusinessReferenceNumber { get; set; }
        public string BusinessLegalName { get; set; }
        public string TradingName { get; set; }
        public string BusinessType { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string OwnerName { get; set; }
        public string TelephoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public long CompanyTurnover { get; set; }
        public string SICCode { get; set; }
        public string VATNumber { get; set; }
        public long NumberOfEmployees { get; set; }
        public long NumberOfDirectors { get; set; }
        public long NumberOfPartnersAndOrShareholders { get; set; }
        public string DateEstablished { get; set; }
        public string DateOfIncorporation { get; set; }
        public string DateOfFiscalYearEnd { get; set; }
        public string OwnershipStartDate { get; set; }
        public string OwnershipEndDate { get; set; }
        public LengthOwnership LengthOwnership { get; set; }
        public long NumberOfPremise { get; set; }
        public BusinessAddress BusinessAddress { get; set; }
        public BusinessBankDetails BusinessBankDetails { get; set; }
        public BusinessContact BusinessContact { get; set; }
        public FinancialDisclosure FinancialDisclosure { get; set; }
    }

    public class Options
    {
        public string AgentID { get; set; }
        public string UserID { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerType { get; set; }
        public string ProductType { get; set; }
        public string BureauProductTypeOverride { get; set; }
        public string IsQuoteFlag { get; set; }
    }

    public class MortgageSpecific
    {
        public long PurchasePrice { get; set; }
        public long PropertyValue { get; set; }
        public long InterestOnlyAmount { get; set; }
        public long MonthlyAmount { get; set; }
        public long MonthlyRentalIncome { get; set; }
        public long InterestRate { get; set; }
        public long LoanToValue { get; set; }
    }

    public class CurrentAccountSpecific
    {
        public string OverdraftRequested { get; set; }
        public long OverdraftLimit { get; set; }
    }

    public class Addon
    {
        public string AddonServiceCode { get; set; }
        public string AddonServiceName { get; set; }
        public long AddonServiceMonthlyReoccurringCharge { get; set; }
    }

    public class Basket
    {
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public long DeviceValue { get; set; }
        public long DeviceOneOffCharge { get; set; }
        public long DeviceMonthlyReoccurringCharge { get; set; }
        public string TariffCode { get; set; }
        public string TariffName { get; set; }
        public long TariffMonthlyReoccurringCharge { get; set; }
        public string FinanceCode { get; set; }
        public string FinanceName { get; set; }
        public long FinanceValue { get; set; }
        public long FinanceOneOffCharge { get; set; }
        public long FinanceMonthlyReoccurringCharge { get; set; }
        public long FinanceAPR { get; set; }
        public long FinanceTerm { get; set; }
        public List<Addon> Addons { get; set; }
        public long ContractTermInMonths { get; set; }
        public string RiskGrade { get; set; }
        public long Quantity { get; set; }
    }

    public class TelecommunicationsSpecific
    {
        public string IsPort { get; set; }
        public string IsTradeIn { get; set; }
        public long TradeInValue { get; set; }
        public long UpfrontPaymentAmount { get; set; }
        public string WholeBasketRiskGrade { get; set; }
        public List<Basket> Basket { get; set; }
    }

    public class Electricity
    {
        public string ContractLength { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingFrequency { get; set; }
        public string ProductType { get; set; }
        public long EstimatedAnnualSpend { get; set; }
        public long EstimatedAnnualConsumption { get; set; }
        public long EstimatedGrossMargin { get; set; }
    }

    public class Gas
    {
        public string ContractLength { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingFrequency { get; set; }
        public string ProductType { get; set; }
        public long EstimatedAnnualSpend { get; set; }
        public long EstimatedAnnualConsumption { get; set; }
        public long EstimatedGrossMargin { get; set; }
    }

    public class UtilitiesSpecific
    {
        public string OccupancyType { get; set; }
        public string SaleType { get; set; }
        public Electricity Electricity { get; set; }
        public Gas Gas { get; set; }
    }

    public class SocialHousingSpecific
    {
        public string DealerName { get; set; }
        public string DealerLegalName { get; set; }
        public string ProgramID { get; set; }
        public string ProgramTierID { get; set; }
        public string Deposit { get; set; }
        public string TenancyType { get; set; }
        public string TenancyCategory { get; set; }
        public long TenancyTermInMonths { get; set; }
        public string PaymentFrequency { get; set; }
        public string PreviousBehaviourIssue { get; set; }
        public string HasWeaponsFlag { get; set; }
        public string HasPetsFlag { get; set; }
        public string PropertyID { get; set; }
        public string PropertyPostcode { get; set; }
        public string PropertyStreetName { get; set; }
        public string PropertyHouseNumber { get; set; }
        public string PropertyFlat { get; set; }
    }

    public class Vehicle
    {
        public long Price { get; set; }
        public long DepositAmount { get; set; }
        public long BalloonPaymentAmount { get; set; }
        public long RepaymentAmount { get; set; }
        public string RepaymentFrequency { get; set; }
        public long RepaymentTermInMonths { get; set; }
        public string InitialRepaymentDate { get; set; }
        public string DeliveryDate { get; set; }
        public string ProductCodeOrId { get; set; }
        public string Condition { get; set; }
        public string Registration { get; set; }
        public long AgeInYears { get; set; }
        public long Mileage { get; set; }
        public string Class { get; set; }
        public string IsMaintained { get; set; }
        public string DealerCode { get; set; }
        public string DealerName { get; set; }
    }

    public class AutomotiveSpecific
    {
        public long TotalNumberOfVehicles { get; set; }
        public long TotalExposure { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Application
    {
        public long Amount { get; set; }
        public long Term { get; set; }
        public string Purpose { get; set; }
        public long PropertyValue { get; set; }
        public string MortgageType { get; set; }
        public long MonthlyAmount { get; set; }
        public long MortgageBalance { get; set; }
        public long LimitApplied { get; set; }
        public long LimitGiven { get; set; }
        public string ApplicationChannel { get; set; }
        public string AuthenticationType { get; set; }
        public string ManualAuthenticationRequired { get; set; }
        public string SearchConsent { get; set; }
        public string PromotionCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductRequiredBy { get; set; }
        public string DateInMonthForRepayments { get; set; }
        public long TargetAPR { get; set; }
        public MortgageSpecific MortgageSpecific { get; set; }
        public CurrentAccountSpecific CurrentAccountSpecific { get; set; }
        public TelecommunicationsSpecific TelecommunicationsSpecific { get; set; }
        public UtilitiesSpecific UtilitiesSpecific { get; set; }
        public SocialHousingSpecific SocialHousingSpecific { get; set; }
        public AutomotiveSpecific AutomotiveSpecific { get; set; }
    }

    public class ClientData
    {
        public string BranchID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceID { get; set; }
        public string TelephoneNumber { get; set; }
        public string LenderID { get; set; }
        public string DealerID { get; set; }
    }

    public class Person
    {
        public string KeyPersonType { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Suffix { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class Location
    {
        public string Flat { get; set; }
        public string HouseName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string District { get; set; }
        public string District2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string LocationLine1 { get; set; }
        public string LocationLine2 { get; set; }
        public string LocationLine3 { get; set; }
        public string LocationLine4 { get; set; }
        public string LocationLine5 { get; set; }
        public string LocationLine6 { get; set; }
        public string BFPOPostcode { get; set; }
        public string POBox { get; set; }
        public string UPRN { get; set; }
    }

    public class Residency
    {
        public string ResidentFrom { get; set; }
        public string ResidentTo { get; set; }
        public string AddressType { get; set; }
        public string SharedLetterbox { get; set; }
        public Location Location { get; set; }
        public string TenancyType { get; set; }
        public long NumberOfBedrooms { get; set; }
        public string IsTemporaryAccommodation { get; set; }
        public string ReasonForLeaving { get; set; }
    }

    public class HomeTelephone
    {
        public string STDCode { get; set; }
        public string LocalNumber { get; set; }
    }

    public class PersonalDetails
    {
        public string MaritalStatus { get; set; }
        public HomeTelephone HomeTelephone { get; set; }
        public string MobileTelNumber { get; set; }
        public string Dependants { get; set; }
        public string ResidentialStatus { get; set; }
        public string EmailAddress { get; set; }
        public string NatInsuranceNum { get; set; }
        public string PassportNumber { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public string PassportCountryOfIssue { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ImmigrationStatus { get; set; }
        public string SpouseName { get; set; }
        public string ChangeInCircumstance { get; set; }
        public string QualificationDetails { get; set; }
    }

    public class VulnerabilityDetails
    {
        public string RegisteredDisabled { get; set; }
        public string CriticallyIllness { get; set; }
        public string MentalIllness { get; set; }
        public string VisualImpairment { get; set; }
        public string HearingImpairment { get; set; }
        public string OtherPhysicalImpairment { get; set; }
        public string MeansTestedBenefits { get; set; }
        public string OtherVulnerability { get; set; }
    }

    public class BankDetails
    {
        public string BankAccountSetupDate { get; set; }
        public string BankSortCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string CurrentAccountHeld { get; set; }
        public string ChequeCardHeld { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string BankAccountHolder { get; set; }
        public string BankAccountContext { get; set; }
        public string BankAccountFlag { get; set; }
    }

    public class BreakdownOfMonthlyIncome
    {
        public long StatutorySickPay { get; set; }
        public long StatePension { get; set; }
        public long WarPension { get; set; }
        public long PrivatePension { get; set; }
        public long SavingsandInvestmentIncome { get; set; }
        public long ChildMaintenance { get; set; }
        public long RentalIncome { get; set; }
        public long SpousalMaintenance { get; set; }
        public long UniversalCredit { get; set; }
        public long WorkingTaxCredit { get; set; }
        public long ChildTaxCredit { get; set; }
        public long HousingBenefit { get; set; }
        public long CouncilTaxSupport { get; set; }
        public long PensionCredit { get; set; }
        public long JobSeekersAllowance { get; set; }
        public long EmploymentandSupportAllowance { get; set; }
        public long IncomeSupport { get; set; }
        public long AttendanceAllowance { get; set; }
        public long DLACare { get; set; }
        public long PIPDailyLiving { get; set; }
        public long DLAMobility { get; set; }
        public long PIPMobility { get; set; }
        public long IncapacityBenefit { get; set; }
        public long IndustrialInjuriesBenefit { get; set; }
        public long SevereDisablementBenefit { get; set; }
        public long ChildBenefit { get; set; }
        public long CarersAllowance { get; set; }
        public long MaternityAllowance { get; set; }
        public long WidowedParentsAllowance { get; set; }
        public long BereavementAllowance { get; set; }
        public long Other { get; set; }
        public long TotalEarningsOtherMembersOfHousehold { get; set; }
    }

    public class DetailedEssentialMonthlyFixedCosts
    {
        public long Rent { get; set; }
        public long Groceries { get; set; }
        public long Gas { get; set; }
        public long Electric { get; set; }
        public long Water { get; set; }
        public long Phone { get; set; }
        public long TravelCosts { get; set; }
        public long Insurances { get; set; }
        public long ChildMaintenance { get; set; }
        public long ChildCare { get; set; }
        public long TotalEssentialFixedCosts { get; set; }
    }

    public class DetailedNonEssentialMonthlyFixedCosts
    {
        public long TV { get; set; }
        public long Broadband { get; set; }
        public long Clothes { get; set; }
        public long HouseholdGoods { get; set; }
        public long LeisureCosts { get; set; }
        public long PersonalGoods { get; set; }
        public long Medical { get; set; }
        public long Memberships { get; set; }
        public long Pets { get; set; }
        public long Holidays { get; set; }
    }

    public class Expenditure
    {
        public string Description { get; set; }
        public long Amount { get; set; }
    }

    public class Expenditures
    {
        public Expenditure Expenditure { get; set; }
    }

    public class FinancialDetails
    {
        public long GrossAnnualIncome { get; set; }
        public long AdditionalAnnualIncome { get; set; }
        public long NetMonthlyIncome { get; set; }
        public BreakdownOfMonthlyIncome BreakdownOfMonthlyIncome { get; set; }
        public long TotalValueOfSavings { get; set; }
        public long MonthlyMortgageAmount { get; set; }
        public long ShareOfMonthlyMortgageAmount { get; set; }
        public long MonthlyCouncilTax { get; set; }
        public long ShareOfMonthlyCouncilTax { get; set; }
        public long MonthlyLoanRepayments { get; set; }
        public long RegularMonthlyOutgoings { get; set; }
        public long TotalValueOfPropertyOwned { get; set; }
        public DetailedEssentialMonthlyFixedCosts DetailedEssentialMonthlyFixedCosts { get; set; }
        public DetailedNonEssentialMonthlyFixedCosts DetailedNonEssentialMonthlyFixedCosts { get; set; }
        public Expenditures Expenditures { get; set; }
    }

    public class Card
    {
        public string TimeHeldMM { get; set; }
        public string TimeHeldYY { get; set; }
        public string isBeingPaidOffWithThisLoan { get; set; }
        public long CurrentBalance { get; set; }
        public long CreditLimit { get; set; }
        public string IsPrimaryCardHolder { get; set; }
    }

    public class Loan
    {
        public long AmountOutstanding { get; set; }
        public long MonthlyPayment { get; set; }
        public string isBeingPaidOffWithThisLoan { get; set; }
    }

    public class Account
    {
        public long ClearedBalance { get; set; }
        public string DateOpened { get; set; }
        public long OverdraftLimit { get; set; }
    }

    public class Mortgage
    {
        public string IsBeingPaidOffWithThisLoan { get; set; }
        public long CurrentBalance { get; set; }
        public long MonthlyRepayment { get; set; }
        public long BalanceAmountContinuing { get; set; }
        public long InterestOnlyAmount { get; set; }
        public string IsPropertyLet { get; set; }
        public string TenancyAgreementInPlace { get; set; }
        public long MonthlyRentalIncome { get; set; }
        public long EstimatedPropertyValue { get; set; }
    }

    public class Asset
    {
        public string PledgedToExistingLoan { get; set; }
        public string PledgedForThisApplication { get; set; }
        public long PledgedAmount { get; set; }
        public long ValueOfAsset { get; set; }
    }

    public class ExistingAccountInformation
    {
        public List<Card> Cards { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Mortgage> Mortgages { get; set; }
        public List<Asset> Assets { get; set; }
    }

    public class MonthlyExpenses
    {
        public long Rent { get; set; }
        public long Mortgage { get; set; }
        public long GroundRent { get; set; }
        public long ServiceCharge { get; set; }
        public long CouncilTax { get; set; }
        public long Gas { get; set; }
        public long Electricity { get; set; }
        public long Water { get; set; }
        public long HomePhone { get; set; }
        public long Internet { get; set; }
        public long TVLicence { get; set; }
        public long SkyDigital { get; set; }
        public long MobilePhone { get; set; }
        public long BuildingandContentsInsurance { get; set; }
        public long LifeInsurance { get; set; }
        public long MobileInsurance { get; set; }
        public long MedicalDentalInsurance { get; set; }
        public long OtherInsurance { get; set; }
        public long ChildcareCosts { get; set; }
        public long BusTrainFares { get; set; }
        public long CarExpenses { get; set; }
        public long FoodDrinkGroceries { get; set; }
        public long PetCosts { get; set; }
        public long GymandOtherSubscriptionFees { get; set; }
        public long EntertainmentHolidays { get; set; }
        public long ClothesandCosmetics { get; set; }
        public long AlcoholSmokingGambling { get; set; }
        public long RegularSavings { get; set; }
        public long PensionContributions { get; set; }
        public long LoanPayments { get; set; }
        public long CreditCardPayments { get; set; }
        public long StoreCardPayments { get; set; }
        public long CataloguePayments { get; set; }
        public long HPAgreements { get; set; }
        public long Overdraft { get; set; }
        public long CourtFines { get; set; }
        public long Prescriptions { get; set; }
        public long OtherCosts { get; set; }
    }

    public class MonthlyArrears
    {
        public long Rent { get; set; }
        public long Mortgage { get; set; }
        public long CouncilTax { get; set; }
        public long CourtFines { get; set; }
        public long CourtOrders { get; set; }
        public long Gas { get; set; }
        public long Electricity { get; set; }
        public long Water { get; set; }
        public long Phone { get; set; }
        public long AllCreditArrears { get; set; }
        public long OtherMonthlyArrears { get; set; }
    }

    public class WorkTelephone
    {
        public string STDCode { get; set; }
        public string LocalNumber { get; set; }
    }

    public class TimeWithEmployer
    {
        public string Years { get; set; }
        public string Months { get; set; }
    }

    public class EmploymentDetails
    {
        public WorkTelephone WorkTelephone { get; set; }
        public TimeWithEmployer TimeWithEmployer { get; set; }
        public string EmployerName { get; set; }
        public string OccupationStatus { get; set; }
        public string EmploymentStatus { get; set; }
        public string JobTitle { get; set; }
        public string IsMilitaryOrDefenceFlag { get; set; }
    }

    public class AdditionalData
    {
        public string DrivingLicenceNum { get; set; }
        public string VehicleRegistration { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MothersMaidenName { get; set; }
        public string BirthSurname { get; set; }
    }

    public class KeyPersonData
    {
        public string CustomerID { get; set; }
        public string VipFlag { get; set; }
        public string IsStaff { get; set; }
        public string FirstTimeBuyerFlag { get; set; }
        public string IsBankruptFlag { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public VulnerabilityDetails VulnerabilityDetails { get; set; }
        public BankDetails BankDetails { get; set; }
        public FinancialDetails FinancialDetails { get; set; }
        public ExistingAccountInformation ExistingAccountInformation { get; set; }
        public MonthlyExpenses MonthlyExpenses { get; set; }
        public MonthlyArrears MonthlyArrears { get; set; }
        public EmploymentDetails EmploymentDetails { get; set; }
        public AdditionalData AdditionalData { get; set; }
    }

    public class Alias
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Suffix { get; set; }
        public string Source { get; set; }
        public string Gender { get; set; }
    }

    public class Association
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string AssociatedFrom { get; set; }
        public string AssociatedTo { get; set; }
    }

    public class KeyPerson
    {
        public Person Person { get; set; }
        public List<Residency> Residencies { get; set; }
        public KeyPersonData KeyPersonData { get; set; }
        public List<Alias> Aliases { get; set; }
        public Association Association { get; set; }
    }

    public class LengthOwnership
    {
        public string Years { get; set; }
        public string Months { get; set; }
    }

    public class BusinessAddress
    {
        public string Flat { get; set; }
        public string HouseName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string District { get; set; }
        public string District2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string ResidentFrom { get; set; }
        public string ResidentTo { get; set; }
    }

    public class BusinessBankDetails
    {
        public string BankSortCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string BankAccountSetupDate { get; set; }
        public string BankAccountContext { get; set; }
    }

    public class ContactTelephone
    {
        public string STDCode { get; set; }
        public string LocalNumber { get; set; }
        public string ExtensionNumber { get; set; }
    }

    public class BusinessContact
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public ContactTelephone ContactTelephone { get; set; }
    }

    public class FinancialDisclosure
    {
        public string FinancialAccountsAvailable { get; set; }
        public long NumberofYearsFinancials { get; set; }
        public string DateOfAccounts { get; set; }
        public long TotalFixedAssets { get; set; }
        public long TangibleAssets { get; set; }
        public long IntangibleAssets { get; set; }
        public long OtherLongTermAssets { get; set; }
        public long TotalCurrentAssets { get; set; }
        public long Stocks { get; set; }
        public long Debtors { get; set; }
        public long CashInBankAndCashInHand { get; set; }
        public long LongTermLiabilities { get; set; }
        public long TotalCurrentLiabilities { get; set; }
        public long CreditorsAndSuppliers { get; set; }
        public long LoansBank { get; set; }
        public long WorkingCapital { get; set; }
        public long TotalAssets { get; set; }
        public long Creditors { get; set; }
        public long CapitalEmployed { get; set; }
        public long TotalNetAssets { get; set; }
        public long ShareholdersFunds { get; set; }
        public long NetWorth { get; set; }
        public long ProfitAndLossCurrentDate { get; set; }
        public long Turnover { get; set; }
        public long TotalCostOfSales { get; set; }
        public long Material { get; set; }
        public long Wages { get; set; }
        public long TotalExpenses { get; set; }
        public long RentAndLeaseCost { get; set; }
        public long Insurance { get; set; }
        public long ProvisionsAndWriteOff { get; set; }
        public long Salaries { get; set; }
        public long Depreciation { get; set; }
        public long InterestCharges { get; set; }
        public long Motor { get; set; }
        public long Other { get; set; }
        public long GrossProfit { get; set; }
        public long PreTaxProfitAndLoss { get; set; }
        public long RetainedProiftAndLoss { get; set; }
        public long Cashflow { get; set; }
        public long Servicibility { get; set; }
        public long CurrentRatio { get; set; }
        public long AcidTestRatio { get; set; }
        public long StockTurnoverRatio { get; set; }
        public long DebtorsTurnoverRatio { get; set; }
        public long CreditorsTurnoverRatio { get; set; }
        public long DebtorsAndCreditorsRatio { get; set; }
        public long WorkingCapitalTurnoverRatio { get; set; }
        public long PreTaxNetProfitMargin { get; set; }
        public long GrossProfitMargin { get; set; }
        public long DebtGearingRatio { get; set; }
        public long EquityGearingRatio { get; set; }
        public long ReturnonTotalAssets { get; set; }
        public long ReturnonCapitalEmployment { get; set; }
        public long InterestCover { get; set; }
        public long SalestoAssets { get; set; }
        public long CostIncomeRatio { get; set; }
        public long DebttoEquityRatio { get; set; }
        public long OperatingCashflowRatio { get; set; }
    }

    public class CustomerAcquisitionSettings
    {
        public string BaseUrl { get; set; }
        public string Client_id { get; set; }
        public string Client_secret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CustomerAcquisitionResponse
    {

    }

    public class CustomerAcquisitionFailedResponse
    {
        public FaultResponse fault { get; set; }
    }

    public class FaultResponse
    {
        public string faultstring { get; set; }
        public FaultDetailResponse detail { get; set; }
    }

    public class FaultDetailResponse
    {
        public string errorcode { get; set; }
    }
}
