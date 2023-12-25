using System.ComponentModel.DataAnnotations;

namespace Api.Enum
{
    public enum TreeType : byte
    {
        Technical = 0,
        Process = 1,
        Location = 2
    }
    public enum SiteAction
    {
        //Post Permission
        Post_View,
        Post_Add,
        Post_Edit,
        Post_Delete,
        Post_Access,

        //Account Permission
        Account_View,
        Account_Add,
        Account_Edit,
        Account_Delete,

        //Country Permission
        Country_View,
        Country_Add,
        Country_Edit,
        Country_Delete,

        //State Permission
        State_View,
        State_Add,
        State_Edit,
        State_Delete,

        //City Permission
        City_View,
        City_Add,
        City_Edit,
        City_Delete,

        //Zone Permission
        Zone_View,
        Zone_Add,
        Zone_Edit,
        Zone_Delete,

        //Package Permission
        Package_View,
        Package_Add,
        Package_Edit,
        Package_Delete,

        //EducationField Permission
        EducationField_View,
        EducationField_Add,
        EducationField_Edit,
        EducationField_Delete,

        //EducationSubField Permission
        EducationSubField_View,
        EducationSubField_Add,
        EducationSubField_Edit,
        EducationSubField_Delete,

        //EducationLevel Permission
        EducationLevel_View,
        EducationLevel_Add,
        EducationLevel_Edit,
        EducationLevel_Delete,

        //AccountAddress Permission
        AccountAddress_View,
        AccountAddress_Add,
        AccountAddress_Edit,
        AccountAddress_Delete,

        //Bank Permission
        Bank_View,
        Bank_Add,
        Bank_Edit,
        Bank_Delete,

        //AccountCheck Permission
        AccountCheck_View,
        AccountCheck_Add,
        AccountCheck_Edit,
        AccountCheck_Delete,

        //CurrencyType Permission
        CurrencyType_View,
        CurrencyType_Add,
        CurrencyType_Edit,
        CurrencyType_Delete,

        //AccountCredit Permission
        AccountCredit_View,
        AccountCredit_Add,
        AccountCredit_Edit,
        AccountCredit_Delete,

        //CreditPayment Permission
        CreditPayment_View,
        CreditPayment_Add,
        CreditPayment_Edit,
        CreditPayment_Delete,

        //Store Permission
        Store_View,
        Store_Add,
        Store_Edit,
        Store_Delete,

        //StorePart Permission
        StorePart_View,
        StorePart_Add,
        StorePart_Edit,
        StorePart_Delete,

        //Supplier Permission
        Supplier_View,
        Supplier_Add,
        Supplier_Edit,
        Supplier_Delete,

        //Unit Permission
        Unit_View,
        Unit_Add,
        Unit_Edit,
        Unit_Delete,

        //Brand Permission
        Brand_View,
        Brand_Add,
        Brand_Edit,
        Brand_Delete,

        //Users Permission
        Users_View,
        Users_Details,
        Users_Add,
        Users_Edit,
        Users_Delete,
        Users_ChangePassword,

        //Groups Permission
        Groups_View,
        Groups_Add,
        Groups_Edit,
        Groups_Delete,
        Groups_Access,

        //UserLog Permission
        UserLog_View,

        //Ticket Permission
        Ticket_View,
        Ticket_Add,
        Ticket_Details,

        //TicketManagement Permission
        TicketManagement_View,
        TicketManagement_Details,
        TicketManagement_Close,

        //CalenderMaker Permission
        CalenderMaker_View,
    }
}
