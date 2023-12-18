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
        //WorkRequestCartable Permission
        WorkRequestCartable_View,
        WorkRequestCartable_EditRepairUnit,
        WorkRequestCartable_Details,
        WorkRequestCartable_Confirm,
        WorkRequestCartable_Dependent,
        WorkRequestCartable_Reject,
        WorkRequestCartable_Hold,
        WorkRequestCartable_UnHold,
        WorkRequestCartable_Suspend,
        WorkRequestCartable_Cancel,
        WorkRequestCartable_DetailsTab,
        WorkRequestCartable_ViewPointTab,
        WorkRequestCartable_CurrentLocationTab,
        WorkRequestCartable_ActivitiesTab,
        WorkRequestCartable_SkillsTab,
        WorkRequestCartable_CostTab,
        WorkRequestCartable_AttachmentTab,
        WorkRequestCartable_FailureTab,
        WorkRequestCartable_DetailsTabView,
        WorkRequestCartable_RequestImportance,
        WorkRequestCartable_IsRequiredEngineering,
        WorkRequestCartable_IsRequireTechnicalInspection,
        WorkRequestCartable_IsRequireCalibration,
        WorkRequestCartable_IsRequireCBM,
        WorkRequestCartable_ViewPointTabView,
        WorkRequestCartable_ViewPointTabAdd,
        WorkRequestCartable_ViewPointTabDelete,
        WorkRequestCartable_CurrentLocationTabView,
        WorkRequestCartable_RepairOperation,
        WorkRequestCartable_PmActivity,
        WorkRequestCartable_RepairOperationView,
        WorkRequestCartable_RepairOperationAdd,
        WorkRequestCartable_RepairOperationEdit,
        WorkRequestCartable_RepairOperationDelete,
        WorkRequestCartable_PmActivityView,
        WorkRequestCartable_PmActivityAdd,
        WorkRequestCartable_PmActivityEdit,
        WorkRequestCartable_SkillsTabView,
        WorkRequestCartable_SkillsTabAdd,
        WorkRequestCartable_SkillsTabEdit,
        WorkRequestCartable_SkillsTabDelete,
        WorkRequestCartable_CostTabView,
        WorkRequestCartable_CostTabAdd,
        WorkRequestCartable_CostTabEdit,
        WorkRequestCartable_CostTabDelete,
        WorkRequestCartable_AttachmentTabView,
        WorkRequestCartable_AttachmentTabAdd,
        WorkRequestCartable_AttachmentTabDelete,
        WorkRequestCartable_FailureTabView,
        WorkRequestCartable_FailureTabAdd,
        WorkRequestCartable_FailureTabEdit,
        WorkRequestCartable_FailureTabDelete,

        //WorkRequestInProgress Permission
        WorkRequestInProgress_View,

        //WorkRequestArchiveCartable Permission
        WorkRequestArchiveCartable_View,

        //Location Permission
        Location_View,
        Location_Add,
        Location_Edit,
        Location_Delete,

        //ProcessSystem Permission
        ProcessSystem_View,
        ProcessSystem_Add,
        ProcessSystem_Edit,
        ProcessSystem_Delete,

        //Post Permission
        Post_View,
        Post_Add,
        Post_Edit,
        Post_Delete,
        Post_Access,

        //Department Permission
        Department_View,
        Department_Add,
        Department_Edit,
        Department_Delete,

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

        //Skill Permission
        Skill_View,
        Skill_Add,
        Skill_Edit,
        Skill_Delete,

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

        //Activity Permission
        Activity_View,
        Activity_Add,
        Activity_Edit,
        Activity_Delete,

        //Supplier Permission
        Supplier_View,
        Supplier_Add,
        Supplier_Edit,
        Supplier_Delete,

        //Machinery Permission
        Machinery_View,
        Machinery_Add,
        Machinery_Edit,
        Machinery_Delete,

        //Equipment Permission
        Equipment_View,
        Equipment_Details,
        Equipment_Add,
        Equipment_Edit,
        Equipment_Delete,
        Equipment_Stop,

        //EquipmentGroup Permission
        EquipmentGroup_View,
        EquipmentGroup_FailureMode,
        EquipmentGroup_Add,
        EquipmentGroup_Edit,
        EquipmentGroup_Delete,

        //FailureMode Permission
        FailureMode_FailureModeView,
        FailureMode_FailureModeAdd,
        FailureMode_FailureModeEdit,
        FailureMode_FailureModeDelete,

        //EquipmentClass Permission
        EquipmentClass_View,
        EquipmentClass_Add,
        EquipmentClass_Edit,
        EquipmentClass_Delete,

        //EquipmentType Permission
        EquipmentType_View,
        EquipmentType_Add,
        EquipmentType_Edit,
        EquipmentType_Delete,

        //StopCause Permission
        StopCause_View,
        StopCause_Add,
        StopCause_Edit,
        StopCause_Delete,

        //ImportanceEquipmentIndex Permission
        ImportanceEquipmentIndex_View,
        ImportanceEquipmentIndex_Add,
        ImportanceEquipmentIndex_Edit,
        ImportanceEquipmentIndex_Delete,

        //Unit Permission
        Unit_View,
        Unit_Add,
        Unit_Edit,
        Unit_Delete,

        //EnergyType Permission
        EnergyType_View,
        EnergyType_Add,
        EnergyType_Edit,
        EnergyType_Delete,

        //Brand Permission
        Brand_View,
        Brand_Add,
        Brand_Edit,
        Brand_Delete,

        //RequestImportance Permission
        RequestImportance_View,
        RequestImportance_Add,
        RequestImportance_Edit,
        RequestImportance_Delete,

        //CauseOfFailure Permission
        CauseOfFailure_View,
        CauseOfFailure_Add,
        CauseOfFailure_Edit,
        CauseOfFailure_Delete,

        //FailureMechanism Permission
        FailureMechanism_View,
        FailureMechanism_Add,
        FailureMechanism_Edit,
        FailureMechanism_Delete,

        //FailureDetection Permission
        FailureDetection_View,
        FailureDetection_Add,
        FailureDetection_Edit,
        FailureDetection_Delete,

        //RepairOperation Permission
        RepairOperation_View,
        RepairOperation_Add,
        RepairOperation_Edit,
        RepairOperation_Delete,

        //HoldCause Permission
        HoldCause_View,
        HoldCause_Add,
        HoldCause_Edit,
        HoldCause_Delete,

        //CostHeading Permission
        CostHeading_View,
        CostHeading_Add,
        CostHeading_Edit,
        CostHeading_Delete,

        //PredefinedHamesh Permission
        PredefinedHamesh_View,
        PredefinedHamesh_Add,
        PredefinedHamesh_Edit,
        PredefinedHamesh_Delete,

        //PMActivity Permission
        PMActivity_View,
        PMActivity_Add,
        PMActivity_Edit,
        PMActivity_Delete,

        //Event Permission
        Event_View,
        Event_Add,
        Event_Edit,
        Event_Delete,

        //Measurement Permission
        Measurement_View,
        Measurement_Add,
        Measurement_Edit,
        Measurement_Delete,

        //PMCard Permission
        PMCard_View,
        PMCard_Add,
        PMCard_Edit,
        PMCard_Delete,

        //EquipmentPlanning Permission
        EquipmentPlanning_View,
        EquipmentPlanning_Details,

        //CalenderMaker Permission
        CalenderMaker_View,

        //WorkRequests Permission
        WorkRequests_View,
        WorkRequests_CM,
        WorkRequests_PM,
        WorkRequests_CBM,
        WorkRequests_GM,
        WorkRequests_TSR,

        //BIUnit Permission
        BIUnit_View,
        BIUnit_Add,
        BIUnit_Edit,
        BIUnit_Delete,

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

        //Report Permission
        ReportByRepairUnit_View,
        ReportHoldByRepairUnit_View,
        ReportByYear_View,
        ReportHoldByRepairUnitGroup_View,
        ReportByWorkTime_View,
        ReportWorkTimeByRepairUnit_View,
        ReportTotalWithWorkTimeByRepairUnit_View,

        //KPI Permission
        KPIByRepairUnit_View,
        KPIByMonth_View,
        KPIPMTimelyImplementationByRepairUnit_View,
        KPIPMTimelyImplementationByMonth_View,
        KPIPMWorkRequestByRepairUnit_View,
        KPIPMWorkRequestByMonth_View,

        //Ticket Permission
        Ticket_View,
        Ticket_Add,
        Ticket_Details,

        //TicketManagement Permission
        TicketManagement_View,
        TicketManagement_Details,
        TicketManagement_Close,
    }
}
