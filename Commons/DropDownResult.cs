namespace SvSupportSales.Commons
{
    public class DropDownResult
    {
        public dynamic Value { get; set; }
        public string  Label { get; set; }

        public DropDownResult(dynamic value, String label)
        {
            this.Value = value;
            this.Label = label;
        }

        public DropDownResult()
        {
        }
    }
}
