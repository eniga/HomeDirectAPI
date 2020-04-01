﻿using System;
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
        public int ConditionCount { get; set; }
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
        public int Spare_61_Numeric { get; set; }
        public int Spare_62_Numeric { get; set; }
        public int Spare_63_Numeric { get; set; }
        public int Spare_64_Numeric { get; set; }
        public int Spare_65_Numeric { get; set; }
        public int Spare_66_Numeric { get; set; }
        public int Spare_67_Numeric { get; set; }
        public int Spare_68_Numeric { get; set; }
        public int Spare_69_Numeric { get; set; }
        public int Spare_70_Numeric { get; set; }
        public int Spare_71_Numeric { get; set; }
        public int Spare_72_Numeric { get; set; }
        public int Spare_73_Numeric { get; set; }
        public int Spare_74_Numeric { get; set; }
        public int Spare_75_Numeric { get; set; }
        public int Spare_76_Numeric { get; set; }
        public int Spare_77_Numeric { get; set; }
        public int Spare_78_Numeric { get; set; }
        public int Spare_79_Numeric { get; set; }
        public int Spare_80_Numeric { get; set; }
        public int Spare_81_Decimal { get; set; }
        public int Spare_82_Decimal { get; set; }
        public int Spare_83_Decimal { get; set; }
        public int Spare_84_Decimal { get; set; }
        public int Spare_85_Decimal { get; set; }
        public int Spare_86_Decimal { get; set; }
        public int Spare_87_Decimal { get; set; }
        public int Spare_88_Decimal { get; set; }
        public int Spare_89_Decimal { get; set; }
        public int Spare_90_Decimal { get; set; }
        public int Spare_91_Decimal { get; set; }
        public int Spare_92_Decimal { get; set; }
        public int Spare_93_Decimal { get; set; }
        public int Spare_94_Decimal { get; set; }
        public int Spare_95_Decimal { get; set; }
        public int Spare_96_Decimal { get; set; }
        public int Spare_97_Decimal { get; set; }
        public int Spare_98_Decimal { get; set; }
        public int Spare_99_Decimal { get; set; }
        public int Spare_100_Decimal { get; set; }
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
        public int CompanyTurnover { get; set; }
        public string SICCode { get; set; }
        public string VATNumber { get; set; }
        public int NumberOfEmployees { get; set; }
        public int NumberOfDirectors { get; set; }
        public int NumberOfPartnersAndOrShareholders { get; set; }
        public string DateEstablished { get; set; }
        public string DateOfIncorporation { get; set; }
        public string DateOfFiscalYearEnd { get; set; }
        public string OwnershipStartDate { get; set; }
        public string OwnershipEndDate { get; set; }
        public LengthOwnership LengthOwnership { get; set; }
        public int NumberOfPremise { get; set; }
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
        public int PurchasePrice { get; set; }
        public int PropertyValue { get; set; }
        public int InterestOnlyAmount { get; set; }
        public int MonthlyAmount { get; set; }
        public int MonthlyRentalIncome { get; set; }
        public int InterestRate { get; set; }
        public int LoanToValue { get; set; }
    }

    public class CurrentAccountSpecific
    {
        public string OverdraftRequested { get; set; }
        public int OverdraftLimit { get; set; }
    }

    public class Addon
    {
        public string AddonServiceCode { get; set; }
        public string AddonServiceName { get; set; }
        public int AddonServiceMonthlyReoccurringCharge { get; set; }
    }

    public class Basket
    {
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public int DeviceValue { get; set; }
        public int DeviceOneOffCharge { get; set; }
        public int DeviceMonthlyReoccurringCharge { get; set; }
        public string TariffCode { get; set; }
        public string TariffName { get; set; }
        public int TariffMonthlyReoccurringCharge { get; set; }
        public string FinanceCode { get; set; }
        public string FinanceName { get; set; }
        public int FinanceValue { get; set; }
        public int FinanceOneOffCharge { get; set; }
        public int FinanceMonthlyReoccurringCharge { get; set; }
        public int FinanceAPR { get; set; }
        public int FinanceTerm { get; set; }
        public List<Addon> Addons { get; set; }
        public int ContractTermInMonths { get; set; }
        public string RiskGrade { get; set; }
        public int Quantity { get; set; }
    }

    public class TelecommunicationsSpecific
    {
        public string IsPort { get; set; }
        public string IsTradeIn { get; set; }
        public int TradeInValue { get; set; }
        public int UpfrontPaymentAmount { get; set; }
        public string WholeBasketRiskGrade { get; set; }
        public List<Basket> Basket { get; set; }
    }

    public class Electricity
    {
        public string ContractLength { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingFrequency { get; set; }
        public string ProductType { get; set; }
        public int EstimatedAnnualSpend { get; set; }
        public int EstimatedAnnualConsumption { get; set; }
        public int EstimatedGrossMargin { get; set; }
    }

    public class Gas
    {
        public string ContractLength { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingFrequency { get; set; }
        public string ProductType { get; set; }
        public int EstimatedAnnualSpend { get; set; }
        public int EstimatedAnnualConsumption { get; set; }
        public int EstimatedGrossMargin { get; set; }
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
        public int TenancyTermInMonths { get; set; }
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
        public int Price { get; set; }
        public int DepositAmount { get; set; }
        public int BalloonPaymentAmount { get; set; }
        public int RepaymentAmount { get; set; }
        public string RepaymentFrequency { get; set; }
        public int RepaymentTermInMonths { get; set; }
        public string InitialRepaymentDate { get; set; }
        public string DeliveryDate { get; set; }
        public string ProductCodeOrId { get; set; }
        public string Condition { get; set; }
        public string Registration { get; set; }
        public int AgeInYears { get; set; }
        public int Mileage { get; set; }
        public string Class { get; set; }
        public string IsMaintained { get; set; }
        public string DealerCode { get; set; }
        public string DealerName { get; set; }
    }

    public class AutomotiveSpecific
    {
        public int TotalNumberOfVehicles { get; set; }
        public int TotalExposure { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Application
    {
        public int Amount { get; set; }
        public int Term { get; set; }
        public string Purpose { get; set; }
        public int PropertyValue { get; set; }
        public string MortgageType { get; set; }
        public int MonthlyAmount { get; set; }
        public int MortgageBalance { get; set; }
        public int LimitApplied { get; set; }
        public int LimitGiven { get; set; }
        public string ApplicationChannel { get; set; }
        public string AuthenticationType { get; set; }
        public string ManualAuthenticationRequired { get; set; }
        public string SearchConsent { get; set; }
        public string PromotionCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductRequiredBy { get; set; }
        public string DateInMonthForRepayments { get; set; }
        public int TargetAPR { get; set; }
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
        public int NumberOfBedrooms { get; set; }
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
        public int StatutorySickPay { get; set; }
        public int StatePension { get; set; }
        public int WarPension { get; set; }
        public int PrivatePension { get; set; }
        public int SavingsandInvestmentIncome { get; set; }
        public int ChildMaintenance { get; set; }
        public int RentalIncome { get; set; }
        public int SpousalMaintenance { get; set; }
        public int UniversalCredit { get; set; }
        public int WorkingTaxCredit { get; set; }
        public int ChildTaxCredit { get; set; }
        public int HousingBenefit { get; set; }
        public int CouncilTaxSupport { get; set; }
        public int PensionCredit { get; set; }
        public int JobSeekersAllowance { get; set; }
        public int EmploymentandSupportAllowance { get; set; }
        public int IncomeSupport { get; set; }
        public int AttendanceAllowance { get; set; }
        public int DLACare { get; set; }
        public int PIPDailyLiving { get; set; }
        public int DLAMobility { get; set; }
        public int PIPMobility { get; set; }
        public int IncapacityBenefit { get; set; }
        public int IndustrialInjuriesBenefit { get; set; }
        public int SevereDisablementBenefit { get; set; }
        public int ChildBenefit { get; set; }
        public int CarersAllowance { get; set; }
        public int MaternityAllowance { get; set; }
        public int WidowedParentsAllowance { get; set; }
        public int BereavementAllowance { get; set; }
        public int Other { get; set; }
        public int TotalEarningsOtherMembersOfHousehold { get; set; }
    }

    public class DetailedEssentialMonthlyFixedCosts
    {
        public int Rent { get; set; }
        public int Groceries { get; set; }
        public int Gas { get; set; }
        public int Electric { get; set; }
        public int Water { get; set; }
        public int Phone { get; set; }
        public int TravelCosts { get; set; }
        public int Insurances { get; set; }
        public int ChildMaintenance { get; set; }
        public int ChildCare { get; set; }
        public int TotalEssentialFixedCosts { get; set; }
    }

    public class DetailedNonEssentialMonthlyFixedCosts
    {
        public int TV { get; set; }
        public int Broadband { get; set; }
        public int Clothes { get; set; }
        public int HouseholdGoods { get; set; }
        public int LeisureCosts { get; set; }
        public int PersonalGoods { get; set; }
        public int Medical { get; set; }
        public int Memberships { get; set; }
        public int Pets { get; set; }
        public int Holidays { get; set; }
    }

    public class Expenditure
    {
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class Expenditures
    {
        public Expenditure Expenditure { get; set; }
    }

    public class FinancialDetails
    {
        public int GrossAnnualIncome { get; set; }
        public int AdditionalAnnualIncome { get; set; }
        public int NetMonthlyIncome { get; set; }
        public BreakdownOfMonthlyIncome BreakdownOfMonthlyIncome { get; set; }
        public int TotalValueOfSavings { get; set; }
        public int MonthlyMortgageAmount { get; set; }
        public int ShareOfMonthlyMortgageAmount { get; set; }
        public int MonthlyCouncilTax { get; set; }
        public int ShareOfMonthlyCouncilTax { get; set; }
        public int MonthlyLoanRepayments { get; set; }
        public int RegularMonthlyOutgoings { get; set; }
        public int TotalValueOfPropertyOwned { get; set; }
        public DetailedEssentialMonthlyFixedCosts DetailedEssentialMonthlyFixedCosts { get; set; }
        public DetailedNonEssentialMonthlyFixedCosts DetailedNonEssentialMonthlyFixedCosts { get; set; }
        public Expenditures Expenditures { get; set; }
    }

    public class Card
    {
        public string TimeHeldMM { get; set; }
        public string TimeHeldYY { get; set; }
        public string isBeingPaidOffWithThisLoan { get; set; }
        public int CurrentBalance { get; set; }
        public int CreditLimit { get; set; }
        public string IsPrimaryCardHolder { get; set; }
    }

    public class Loan
    {
        public int AmountOutstanding { get; set; }
        public int MonthlyPayment { get; set; }
        public string isBeingPaidOffWithThisLoan { get; set; }
    }

    public class Account
    {
        public int ClearedBalance { get; set; }
        public string DateOpened { get; set; }
        public int OverdraftLimit { get; set; }
    }

    public class Mortgage
    {
        public string IsBeingPaidOffWithThisLoan { get; set; }
        public int CurrentBalance { get; set; }
        public int MonthlyRepayment { get; set; }
        public int BalanceAmountContinuing { get; set; }
        public int InterestOnlyAmount { get; set; }
        public string IsPropertyLet { get; set; }
        public string TenancyAgreementInPlace { get; set; }
        public int MonthlyRentalIncome { get; set; }
        public int EstimatedPropertyValue { get; set; }
    }

    public class Asset
    {
        public string PledgedToExistingLoan { get; set; }
        public string PledgedForThisApplication { get; set; }
        public int PledgedAmount { get; set; }
        public int ValueOfAsset { get; set; }
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
        public int Rent { get; set; }
        public int Mortgage { get; set; }
        public int GroundRent { get; set; }
        public int ServiceCharge { get; set; }
        public int CouncilTax { get; set; }
        public int Gas { get; set; }
        public int Electricity { get; set; }
        public int Water { get; set; }
        public int HomePhone { get; set; }
        public int Internet { get; set; }
        public int TVLicence { get; set; }
        public int SkyDigital { get; set; }
        public int MobilePhone { get; set; }
        public int BuildingandContentsInsurance { get; set; }
        public int LifeInsurance { get; set; }
        public int MobileInsurance { get; set; }
        public int MedicalDentalInsurance { get; set; }
        public int OtherInsurance { get; set; }
        public int ChildcareCosts { get; set; }
        public int BusTrainFares { get; set; }
        public int CarExpenses { get; set; }
        public int FoodDrinkGroceries { get; set; }
        public int PetCosts { get; set; }
        public int GymandOtherSubscriptionFees { get; set; }
        public int EntertainmentHolidays { get; set; }
        public int ClothesandCosmetics { get; set; }
        public int AlcoholSmokingGambling { get; set; }
        public int RegularSavings { get; set; }
        public int PensionContributions { get; set; }
        public int LoanPayments { get; set; }
        public int CreditCardPayments { get; set; }
        public int StoreCardPayments { get; set; }
        public int CataloguePayments { get; set; }
        public int HPAgreements { get; set; }
        public int Overdraft { get; set; }
        public int CourtFines { get; set; }
        public int Prescriptions { get; set; }
        public int OtherCosts { get; set; }
    }

    public class MonthlyArrears
    {
        public int Rent { get; set; }
        public int Mortgage { get; set; }
        public int CouncilTax { get; set; }
        public int CourtFines { get; set; }
        public int CourtOrders { get; set; }
        public int Gas { get; set; }
        public int Electricity { get; set; }
        public int Water { get; set; }
        public int Phone { get; set; }
        public int AllCreditArrears { get; set; }
        public int OtherMonthlyArrears { get; set; }
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
        public int NumberofYearsFinancials { get; set; }
        public string DateOfAccounts { get; set; }
        public int TotalFixedAssets { get; set; }
        public int TangibleAssets { get; set; }
        public int IntangibleAssets { get; set; }
        public int OtherLongTermAssets { get; set; }
        public int TotalCurrentAssets { get; set; }
        public int Stocks { get; set; }
        public int Debtors { get; set; }
        public int CashInBankAndCashInHand { get; set; }
        public int LongTermLiabilities { get; set; }
        public int TotalCurrentLiabilities { get; set; }
        public int CreditorsAndSuppliers { get; set; }
        public int LoansBank { get; set; }
        public int WorkingCapital { get; set; }
        public int TotalAssets { get; set; }
        public int Creditors { get; set; }
        public int CapitalEmployed { get; set; }
        public int TotalNetAssets { get; set; }
        public int ShareholdersFunds { get; set; }
        public int NetWorth { get; set; }
        public int ProfitAndLossCurrentDate { get; set; }
        public int Turnover { get; set; }
        public int TotalCostOfSales { get; set; }
        public int Material { get; set; }
        public int Wages { get; set; }
        public int TotalExpenses { get; set; }
        public int RentAndLeaseCost { get; set; }
        public int Insurance { get; set; }
        public int ProvisionsAndWriteOff { get; set; }
        public int Salaries { get; set; }
        public int Depreciation { get; set; }
        public int InterestCharges { get; set; }
        public int Motor { get; set; }
        public int Other { get; set; }
        public int GrossProfit { get; set; }
        public int PreTaxProfitAndLoss { get; set; }
        public int RetainedProiftAndLoss { get; set; }
        public int Cashflow { get; set; }
        public int Servicibility { get; set; }
        public int CurrentRatio { get; set; }
        public int AcidTestRatio { get; set; }
        public int StockTurnoverRatio { get; set; }
        public int DebtorsTurnoverRatio { get; set; }
        public int CreditorsTurnoverRatio { get; set; }
        public int DebtorsAndCreditorsRatio { get; set; }
        public int WorkingCapitalTurnoverRatio { get; set; }
        public int PreTaxNetProfitMargin { get; set; }
        public int GrossProfitMargin { get; set; }
        public int DebtGearingRatio { get; set; }
        public int EquityGearingRatio { get; set; }
        public int ReturnonTotalAssets { get; set; }
        public int ReturnonCapitalEmployment { get; set; }
        public int InterestCover { get; set; }
        public int SalestoAssets { get; set; }
        public int CostIncomeRatio { get; set; }
        public int DebttoEquityRatio { get; set; }
        public int OperatingCashflowRatio { get; set; }
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
