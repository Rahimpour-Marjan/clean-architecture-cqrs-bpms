namespace Domain
{
    public class AccountCheck
    {
        protected AccountCheck() { }

        public AccountCheck(int accountId, string checkNumber, int bankId, string branchName, long amount, string payTo, DateTime issueDate, DateTime receiptDate, DateTime? returnDate, string frontImageUrl, string backImageUrl, string? signatureUrl, int creatorId)
        {
            AccountId = accountId;
            CheckNumber = checkNumber;
            BankId = bankId;
            BranchName = branchName;
            Amount = amount;
            PayTo = payTo;
            IssueDate = issueDate;
            ReceiptDate = receiptDate;
            ReturnDate = returnDate;
            FrontImageUrl = frontImageUrl;
            BackImageUrl = backImageUrl;
            SignatureUrl = signatureUrl;
            CreatorId = CreatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string CheckNumber { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public string BranchName { get; set; }
        public long Amount { get; set; }
        public string PayTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string FrontImageUrl { get; set; }
        public string BackImageUrl { get; set; }
        public string? SignatureUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}